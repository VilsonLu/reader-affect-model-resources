import os
import nltk
from collections import Counter

# Counts the number of times an emotion is mentioned from the extracted reviews

filenamelist = os.listdir("./Reviews_Extracted")
emotionlist = list()

print "Parsing all extracted emotions to single list..."
for filename in filenamelist:
    print "Reading '"+filename+"' file..."
    file = open("Reviews_Extracted/"+filename).read()

    print "Appyling tokenization..."
    tokens1 = nltk.word_tokenize(file.decode("utf-8"))
    tokens2 = list()

    print "Normalizing tokens..."
    for token in tokens1:
        tokens2.append(token.lower())

    print "Adding tokens to emotionlist..."
    emotionlist.extend(tokens2)

print "Get frequency..."
emotionCtr = Counter(emotionlist)

newfile1 = open("extractedemotion_counter.txt", "w")
newfile2 = open("extractedemotion_unique.txt", "w")
for k, v in emotionCtr.most_common():
    newfile1.write(str(k)+" "+str(v)+"\n")
    newfile2.write(str(k) + "\n")

newfile1.close()
newfile2.close()
