import os
import re
import nltk
from nltk.stem import WordNetLemmatizer

# Extracts all the emotions mentioned in the review

filenamelist = os.listdir("./Reviews")
emotionfilename = "masterlist_cleaned"

print "Reading emotion list file..."
file = open(emotionfilename+".txt").read()

print "Parsing emotion list file to emotionlist..."
emotionlist = nltk.word_tokenize(file)

for filename in filenamelist:
    print "Reading '"+filename+"' file..."
    file = open("Reviews/"+filename).read()

    print "Appyling tokenization..."
    tokens = nltk.word_tokenize(file.decode("utf-8"))

    lemmatizer = WordNetLemmatizer()
    lemmalist = list()
    print "Appyling lemmatization..."
    for token in tokens:
        lemmalist.append(lemmatizer.lemmatize(token, "v"))

    newfile = open("Reviews_Extracted/"+ filename[:-4] +"_extract.txt", "w")
    print "Extracting emotion words..."
    for word in lemmalist:
        for emotion in emotionlist:
            searchObj = re.match(emotion, word, re.I)
            #print("Attempting to find '" + emotion + "' in '" + word+"'"),
            if searchObj:
                #print(">>>>>>>>>> Found: ", searchObj.group())
                newfile.write(searchObj.group() + "\n")
            #else:
            #    print(">>> Not found.")

    newfile.close()
    print "Done...\n"
