#!/usr/bin/env bash

DATA_DIR=$HOME/data
mkdir $DATA_DIR

# Download MARCO
MARCO_DIR=$DATA_DIR/marco
mkdir $MARCO_DIR
wget https://msmarco.blob.core.windows.net/msmarco/train_v2.0.tar.gz -O $MARCO_DIR/train_v2.0.tar.gz
wget https://msmarco.blob.core.windows.net/msmarco/dev_v2.0.tar.gz -O $MARCO_DIR/dev_v2.0.tar.gz
wget https://msmarco.blob.core.windows.net/msmarco/eval_v2.0.tar.gz -O $MARCO_DIR/eval_v2.0.tar.gz

# Unzip
tar -xvzf $MARCO_DIR/train_v2.0.tar.gz
tar -xvzf $MARCO_DIR/dev_v2.0.tar.gz
tar -xvzf $MARCO_DIR/eval_v2.0.tar.gz

# Download CNN and DailyMail
# Download at: http://cs.nyu.edu/~kcho/DMQA/

# Download GloVe
GLOVE_DIR=$DATA_DIR/glove
mkdir $GLOVE_DIR
wget http://nlp.stanford.edu/data/glove.6B.zip -O $GLOVE_DIR/glove.6B.zip
unzip $GLOVE_DIR/glove.6B.zip -d $GLOVE_DIR

# Download NLTK (for tokenizer)
# Make sure that nltk is installed!
python3 -m nltk.downloader -d $HOME/nltk_data punkt
