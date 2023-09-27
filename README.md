# Help Desk Tool
This tool is to help the help desk perform common tasks for the depots, such as clearing container requests and 
status and substatus changes, with more features to come. 

# Steps for install: 
1. Drag Folder with exe and files to computer ("Release")
2. Run the iGPS Help Desk tool exe, and enter the Site ID (The name of the computer)
3. Then a login will appear and enter the login information for the database
4. After a successful connection it will show the clear container tab, go to settings and ensure the site id and 
path are correct and click save. This will reset the application to change and load configuration. 
5. When the app reloads, it will go straight to the login screen. 
6. If the site id is incorrect, it will not allow user to login, so you'll have to go into the config xml and change 
the site id manually, or set it to empty and it will prompt again.


## First tab:Clear Container Requests
1. Enter list of GLNS (Should not have ' around them or commas)
    a. OR Click Get DNUS and it will pull all DNU containers (Will reload so cannot do both)
2. Click Show Content
3. Review the Containers are correct
4. Click Save Content
5. Click Clear Containers

## Second Tab: Status Change
1. Enter list of GLNS (Should not have ' around them or commas)
2. Enter Status
3. Enter Substatus
4. Click Submit