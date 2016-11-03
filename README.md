Requirements and Instructions

•	Spend no longer than three hours on this problem. 
•	Write the code in your usual style using C#. 
•	Do not use external functionality to directly solve the problem – in particular do not use the built-in C# String class methods to find matches or substrings, for example the lastIndexOf() method, Regex libraries, Linq or similar. You may however hold Strings while your own algorithm does the matching. 

•	Write an MVC application that fulfils the following requirements: 

o	Accepts two strings as input parameters: one string is called “text” and the other is called “subtext” in this problem statement.
o	The application matches the subtext against the text, outputting the character positions of the beginning of each match for the subtext within the text. 
o	Multiple matches are possible. 
o	Matching is case insensitive. 
o	The application should be called “TextMatch” 
o	The results/output text should only contain the character positions with a comma between each position.  No spaces or other formatting should be returned.
o	The matches should be displayed within the MVC app.

Examples of Test Data:

Input text is Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea

Subtext
	Polly
Output
	1, 26, 51
Subtext
	Polly
Output
	1, 26, 51
Subtext
	ll (ell ell)
Output
	3, 28, 53, 78, 82
Subtext
	X
Output
	There is no output
Subtext
	Polx
Output
	There is no output


Your code will be assessed as if it was a commercial application.  Your submission should include a Visual studio solution of your program. 



















