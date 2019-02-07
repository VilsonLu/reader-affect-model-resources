import os
import nltk
from nltk.stem import WordNetLemmatizer

# Creates the masterlist of emotions from all the lists in ./Emotions

filenamelist = os.listdir("./Emotions")
masterlist = open("masterlist.txt", "w")
for filename in filenamelist:
    file = open("Emotions/"+filename).read()
    print "Parsing '"+filename+"' to wordlist..."
    wordlist = nltk.word_tokenize(file)

    newfile = open("Emotions_Lemma/"+ filename[:-4] + "_lemma.txt", "w")
    lemmatizer = WordNetLemmatizer()
    print "Appyling lemmatization..."
    for word in wordlist:
        temp = lemmatizer.lemmatize(word, "v")+"\n"
        newfile.write(temp)
        masterlist.write(temp)

    newfile.close()
    print "Done...\n"

masterlist.close()
