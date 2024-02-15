# MovieManagement
API SETUP
Clone and open Movie-Api  in VS 
then try to  Edit the server and DataBase details in the Appsettings.Json
and add the required JWT key and Values as you required 
and DO migration to DataBase for Table cration and to generate migration file under /migration

Cmd to Migration :
#Add-Migration "migration name"
#update-database

Then try to include all the Packages required accordinmg to version .Net 6
and try to run the Project you will see the Swagger page open 
Added Authentication by giving the username and password you are able to generate a token which will validate the request


and payloads for Adding a Movie #Sample

{
  "title": "DON",
  "movieLanguage": "Hindi",
  "releaseYear": "2016",
  "ott": "Netflix",
  "actors": [
{

"movieId": 1,
      "actorId": 1
    }
  ],
  "ratings": [
    
    {
      "movieId": 1,
      "rating": 3,
      "review": "Good",
      "timestamp": "2024-02-15T07:28:19.154Z"
    }
  ]
}


Attached Postman Collection as well to Better understanding 

UI SETUP

After successfully Running APi still running

try to clone the UI Movie-app and try to run by giving Cmd #npm start 
then you will able to see the page opend with the data regarding the movies and actors in web page 

try to implement more to update the movie and add movie forms in UI will try further

Thank you 



