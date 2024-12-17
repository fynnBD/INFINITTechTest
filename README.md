**

## INFINIT TECH TEST

**

Hi there! Heres a quick n cheap version of the API call you asked for in the brief. Its essentially a pretty simple tree traversal of the GitHub API, followed by another depth-first API call recursion which grabs the content of all the .JS files and adds them to a letter list dictionary.

Its also got a very simple WinForms frontend which shows you the directory structure, followed by the letter stats. 

This took me about 3ish hours of work split across a few sessions (very busy weekend). There are a lot of things I would have added if I was able to spend more time on it including

 - proper commenting
 - Moq-ing the API call for better testing
 - Not half-assing the multithreading
 - making it a bit more extendable
 
 I think the underlying order of operations in the API call process is pretty sound **however**, if there is a way to get the full directory of a repo in one API, I would have used that instead. Im surprised that there isnt one already!
## Things you will need to run this
 - Visual Studio
 - a GitHub API key
 - Patience
## How to run
 - Download repo.
 - Open it in visual studio (or intellij, should still work)
 - **ENTER YOUR GITHUB API KEY IN THE APP.CONFIG FILE** will not work without
 - Hit that run button on INFINITTechTest and pray to your deity of choice


Let me know if theres any issues!
