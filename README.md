# episerver-master-language-switcher
An episerver project that demonstrates how to change the master language after a site has been created.

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

<div class="note"></div>       
**NOTE**: Administrators for this service reserve the right to moderate all information used, shared, or stored with this service at any time. Any user that cannot abide by this disclaimer and Code of Conduct may be subject to action, up to and including revoking access to services.

The material embodied in this software is provided to you "as-is" and without warranty of any kind, express, implied or otherwise, including without limitation, any warranty of fitness for a particular purpose. In no event shall the Made To Engage be liable to you or anyone else for any direct, special, incidental, indirect or consequential damages of any kind, or any damages whatsoever, including without limitation, loss of profit, loss of use, savings or revenue, or the claims of third parties, whether or not Made To Engage has been advised of the possibility of such loss, however caused and on any theory of liability, arising out of or in connection with the possession, use or performance of this software.
