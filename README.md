# C# School Project

## Task 1

###### Create an application Dictionaries.
The main purpose of the project is to store dictionaries in many languages and allow the user to find the translation of a word or a phrase.

The interface must provide the following:
  - Create a dictionary. Specify the type of dictionary at creation. For example, English-Russian or Russian-English.
  - Add a word and its translation to the already existing dictionary. Because one word may have multiple translations, allow creating multiple translation variants.
  - Replace a word or its translation in the dictionary.
  - Delete a word or a translation. If one word is deleted, all its translations are deleted as well. One cannot delete a word translation if this is the last translation variant.
  - Search for translation of a word.
  - Dictionaries must be stored in files.
  - One can export a word and its translations to a separate result file.
  - When the program starts, display the menu to work with the program. If a selected menu item opens a submenu, provide returning to the previous menu.

## Task 2

###### Create an application Quiz.
Its main objective is to provide users with the possibility to test their knowledge in different areas.

The interface must provide the following:
  - When the app starts, the user enters her username and password. If the user is not registered, she must go through the registration process.
  - Things to be specified:
    * Username (one cannot register an already existing username);
    * Password;
    * Date of birth.
  - After logging in, the user can:
    * Start a new quiz;
    * View the results of her previous quizzes;
    * View top 20 for a specific quiz;
    * Change settings. Edit password and date of birth;
    * Log out.
  - To start a new quiz, the user must select the knowledge section, for instance, History, Geography, Biology, etc. Also, provide a mixed quiz, where questions are randomly selected from different quizzes.
  - Each quiz consists of 20 questions. Each question may have one or multiple correct answers. If a question has multiple correct answers, and the user selects not all of    them, the answer is still wrong.
  - After the quiz ends, the user sees the number of correct answers and her place in the table of results among all players. 
  
  Also, develop a utility that creates and edits quizzes and their questions. This app must provide a username and password to authenticate users.
