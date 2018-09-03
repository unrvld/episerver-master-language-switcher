# Episerver Master Language Switcher
An episerver project that demonstrates how to change the master language after a site has been created.

Based upon a project by Adam Najmanowicz https://blog.najmanowicz.com/2009/04/06/advanced-language-manipulation-tool-for-episerver/ and updated to Episerver 11.

Setup Project
1. Clone the repository to your local machine
2. Create a database and update the connectionstring in the web.config
3. Run the episerver database initialisation command "Initialize-EPiDatabase".
4. Run the solution.
5. Create a user account to login to episerver.

The above should setup a standard Episerver Alloy MVC site.

Setup Master Language Switcher
1. Run the following script against your database "sql/switchLang.sql". This will create 3 stored procedures in your database.
2. Run the solution if not already doing so and enable a new language within episerver.
3. Also enable the language under the root and start page nodes.
4. Navigate to 'CMS > Admin> Advanced Language Tool'.
5. Select the page in the tree you would like to change the master language of.
6. Select the language you would like to switch the master language to.
7. Choose an option of just switching or convert.
8. Choose whether to perform this operation recursively against all child pages.
9. Click the 'Change Language' button.

If you followed the above steps you should now be able to return to the 'CMS > Admin' and see that the master language has now been switched.
