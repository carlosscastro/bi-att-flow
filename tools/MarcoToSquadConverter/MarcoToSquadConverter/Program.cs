using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoToSquadConverter
{
    public static class SquadMarcoDataConverter
    {
        public static string ToSquadFormat(IEnumerable<string> marcoJson)
        {
            var targetDataset = new SquadDataset();
            var targetEntries = new List<SquadEntry>();

            int count = 0;
            int notFoundCount = 0;

            foreach (var json in marcoJson)
            {
                var marcoQnA = JsonConvert.DeserializeObject<MsMarcoPassageQuestionAndAnswer>(json);

                var context = string.Join(" ", marcoQnA.Passages.Where(p => p.IsSelected == 1).OrderByDescending(p => p.IsSelected).Select(p => p.PassageText)).ToLowerInvariant();
                if (marcoQnA.Answers.Count() > 0)
                {
                    var answerText = marcoQnA.Answers[0].ToLowerInvariant();

                    if (count % 100 == 0)
                    {
                        Console.Write($"Processing QnA pair # {count}");
                    }

                    var squadQnA = new SquadParagraph()
                    {
                        Context = context,
                        QuestionAndAnswers = new SquadQuestionAndAnswers[1]
                        {
                        new SquadQuestionAndAnswers()
                        {
                            Question = marcoQnA.Query.ToLowerInvariant(),
                            Answers = new SquadAnswer[1]
                            {
                                new SquadAnswer()
                                {
                                    Text = answerText,
                                    AnswerStart = context.Contains(answerText) ? context.IndexOf(answerText) : -1
                                }
                            },
                            Id = marcoQnA.QueryId.ToString()
                        }
                        }
                    };
                    count++;
                    if (squadQnA.QuestionAndAnswers[0].Answers[0].AnswerStart == -1)
                    {
                        notFoundCount++;
                        if (notFoundCount % 100 == 0)
                            Console.WriteLine($"Not Found update # {notFoundCount}");

                    }
                    else
                    {
                        targetEntries.Add(new SquadEntry() { Paragraphs = new SquadParagraph[1] { squadQnA }, Title = marcoQnA.Passages.Where(p => p.IsSelected == 1).OrderByDescending(p => p.IsSelected).First().Url });
                    }
                }


            }

            Console.WriteLine("****************************************************");
            Console.WriteLine($"Count: {count}");
            Console.WriteLine($"Not found count: {notFoundCount}");
            Console.WriteLine("****************************************************");

            targetDataset.Data = targetEntries.ToArray();
            return JsonConvert.SerializeObject(targetDataset);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Test Squad object model
            var squadJson = File.ReadAllText(@"C:\Users\ccastro\Desktop\Papers\squad_dev.json");
            var deserializedSquad = JsonConvert.DeserializeObject<SquadDataset>(squadJson);

            // Train data
            var jsonTrainLines = File.ReadLines(@"C:\Users\ccastro\Desktop\Papers\train_v1.1.json");
            var squadTrainJson = SquadMarcoDataConverter.ToSquadFormat(jsonTrainLines);
            File.WriteAllText(@"C:\Users\ccastro\Desktop\Papers\msmarco_train_squadformat.json", squadTrainJson);

            // Dev data  
            var jsonDevLines = File.ReadLines(@"C:\Users\ccastro\Desktop\Papers\dev_v1.1.json");
            var squadDevJson = SquadMarcoDataConverter.ToSquadFormat(jsonDevLines);
            File.WriteAllText(@"C:\Users\ccastro\Desktop\Papers\msmarco_dev_squadformat.json", squadDevJson);

            Console.ReadLine();
        }
    }
}
