# SiteScraper
Sample Project

# Requirements
Write a small user friendly program that allows the user to type a URL for a given website page and the program will then do the following:

1. List all images and show them to the user appropriately in a carousel or gallery control of some kind (borrow from the internet or write your own)

2. Count all the words (display the total) and display the top 10 occurring words and their count (eithers as a table or chart of some kind, again you choose or write your own)

# Notes
* Added Dependancy Injection
* Added a unit test example
* Used Bootstrap (inlcuding carousel control)
* Kept validation simple for this example
* Used simple regex for getting words
* Used Lambda to get Top 10 words
* Used HttpClient instead of WebClient to show what code would look like if scaled out (and many web requests were being made as opposed to this simple example.)
* Have methods for simple word count and also method for getting word count based on cleaned up html
