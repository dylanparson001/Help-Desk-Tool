# Help Desk Tool
This tool is to help the help desk perform common tasks for the depots, clearing containers, GRAI removal, removing orders and rollbacks. 

## Instructions for Clear Container Request
- Enter list of GLNs that will be cleared. There should be no commas, quotes, only the GLN and a new line.
- Click Show Content, information from  table should appear in the right table
- Click Save Content, if taking a snapshot it will take a bit longer. On older computers the snapshot may fail out due to low memory. closing other apps should fix this, if not you can save without the snapshot
- Once confirmed that the csv saved successfully, click Clear Containers (red button)
- Confirm you want to delete the containers and click Yes

## Instructions for Rollback
- Enter the BOL and click Search BOL button
- Click the checkbox for the correct Order ID (it will show status and total grais completed should help decide)
- Click Select Order Button
- Search for the container that you want to rollback the scans into (search works for Description and GLN)
- Click checkbox for the container, ensure there are no scans in the container already
- Click the Select Container Button
- Confirm all information at the bottom looks correct
- Click Rollback button
- If the GRAIs are already in the computer, the tool will save and delete them and then attempt one more time. 
