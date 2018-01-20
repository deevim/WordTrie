# WordTrie

* Total compisite words : 160284
* Longest composite word : 			ethylenediaminetetraacetate
* Second composite longest word : 	electroencephalographicall

The project uses a trie data structure to efficiently store and retrieve words from the master list.

Assumptions : 
* Each line contains a non-empty word. Empty strings are ignored.
* Code assumes all characters across all words are in lower case. 'Aa' and 'aa' will be considered as different words.
* The code base uses the 'char' data structure because of which functioning of this code base with special characters (beyond the basic ASCII character set) including characters with accents is not certain.
* The implementation of a trie in this case uses a dictionary in each node of the trie. More efficient approaches are possible, but this approach was efficient enough for the given data set and considering the time constraint for the test. 
