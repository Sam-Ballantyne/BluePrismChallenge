Author: Sam Ballantyne
Date: 25/02/2019

Description:

This is my implementation for the BluePrism coding challenge as described in the specification provided:

Write a program in VB.NET/C#.NET with a command line interface which calls a procedure that takes four parameters as follows: 
DictionaryFile - the file name of a text file containing four letter words (included in the test pack) 
StartWord - a four letter word (that you can assume is found in the DictionaryFile file) 
EndWord - a four letter word (that you can assume is found in the DictionaryFile file)  
ResultFile - the file name of a text file that will contain the result 

The result is the shortest list of four letter words, starting with StartWord, and ending with EndWord, with a number of intermediate words that must appear in the DictionaryFile file where each word differs from the previous word by one letter only. 
For example, if StartWord = Spin, EndWord = Spot and DictionaryFile file contains 
Spin 
Spit 
Spat 
Spot 
Span 

then ResultFile should contain 
Spin 
Spit 
Spot 

Two examples of incorrect results: 
Spin, Span, Spat, Spot (incorrect as it takes 3 changes rather than 2) 
Spin, Spon, Spot (incorrect as spon is not a word)

Your solution should deal with the case where the dictionary file is not in alphabetical order. 

The solution:

This orchestrates the running of the system. First creating an instance of the TextFileReader class. This when initialised the file reader takes the length of the word as a parameter. This allows it to do an initial filtering of the dictionary, removing all the words which do not match this length. This should make the searching quicker later on in the system as it greatly reduces the number of potential matches. 

The input handler checks that the input words exist using a helper function in the file reader class and that the words themselves are four character long. If not then the error message is returned. If these preliminary checks are passed an instance of the WordMatcher class is created. 

The purpose of this WordMatcher class when run is to create a tree of Word objects. This tree is linked by the string literals of words found in the dictionary which differ by one index. When creating the tree all words which differ by more than one index in the dictionary (relative to the current word) are returned. If these do not get any closer to the end word (IE the difference between the two mismatch indexes hasn’t been reduced).

Once this tree structure has been returned it is passed to a shortest path algorithm to find the shortest path to the shallowest node which contains the given value. This is then returned and formatted to output to the console and written to the text results file

Testing:

I have also included some basic unit testing of both my services and model. Although most of the functionality has been tested there are more edge cases I would like to test particularly with the shortest path class.

Optimisation:

As I mentioned the main optimisation was to remove as much of the dictionary as possible (that didn't match the word length). Plus disregarding all possible paths which didn't get closer the desired end result.


WARNING: The word matcher tests and text file reader tests will FAIL unless the path to the appropriate files are added