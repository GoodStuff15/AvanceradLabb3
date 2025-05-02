Anrop:

- [X]  Hämta alla personer i systemet

curl -X 'GET' \
  'https://localhost:7040/api/People' \
  -H 'accept: text/plain'

  Request URL
https://localhost:7040/api/People
Server response
Code	Details
200	
Response body
Download
[
  {
    "firstName": "Gustav",
    "lastName": "Eriksson",
    "email": "vd@swedbonk.se",
    "age": 42,
    "interests": [
      {
        "title": "Magic The Gathering",
        "description": "A collectible card game, and its rewarding and strategic gameplay, compelling characters, and fantastic Multiverse have entertained and delighted fans for more than 30 years. With more than 50 million fans to date, MAGIC is a worldwide phenomenon published in more than 150 countries."
      },
      {
        "title": "Mecka",
        "description": "Skruva och ha sig lite"
      }
    ],
    "links": [
      {
        "title": "string",
        "url": "string"
      },
      {
        "title": "EDHREC",
        "url": "http://www.edhrec.com"
      }
    ]
  },
  {
    "firstName": "McGyver",
    "lastName": "Jonsson",
    "email": "mackans@bygghemma.se",
    "age": 72,
    "interests": [
      {
        "title": "Mecka",
        "description": "Skruva och ha sig lite"
      },
      {
        "title": "Slåss",
        "description": "Slåss pang bom krasch!!"
      }
    ],
    "links": [
      {
        "title": "Jula",
        "url": "http://www.jula.se"
      },
      {
        "title": "Kingen",
        "url": "http://www.miketyson.se"
      }
    ]
  },
  {
    "firstName": "Jean Claude",
    "lastName": "Van Damme",
    "email": "jean-claude.vandamme@swipnet.se",
    "age": 63,
    "interests": [
      {
        "title": "Magic The Gathering",
        "description": "A collectible card game, and its rewarding and strategic gameplay, compelling characters, and fantastic Multiverse have entertained and delighted fans for more than 30 years. With more than 50 million fans to date, MAGIC is a worldwide phenomenon published in more than 150 countries."
      },
      {
        "title": "Slåss",
        "description": "Slåss pang bom krasch!!"
      }
    ],
    "links": []
  }
]
Response headers
 content-type: application/json; charset=utf-8 
 date: Fri,02 May 2025 07:18:55 GMT 
 server: Kestrel 
 

- [X]  Hämta alla intressen kopplade till en specifik person

curl -X 'GET' \
  'https://localhost:7040/api/Interest/Details?personId=2' \
  -H 'accept: text/plain'

  Server response
Code	Details
200	
Response body
Download
[
  {
    "title": "Magic The Gathering",
    "description": "A collectible card game, and its rewarding and strategic gameplay, compelling characters, and fantastic Multiverse have entertained and delighted fans for more than 30 years. With more than 50 million fans to date, MAGIC is a worldwide phenomenon published in more than 150 countries."
  },
  {
    "title": "Mecka",
    "description": "Skruva och ha sig lite"
  }
]
Response headers
 content-type: application/json; charset=utf-8 
 date: Fri,02 May 2025 07:19:54 GMT 
 server: Kestrel 

- [X]  Hämta alla länkar kopplade till en specifik person
curl -X 'GET' \
  'https://localhost:7040/api/Link/Details?personId=2' \
  -H 'accept: text/plain'

Request URL
https://localhost:7040/api/Link/Details?personId=1
Server response
Code	Details
200	
Response body
Download
[
  {
    "title": "string",
    "url": "string"
  },
  {
    "title": "EDHREC",
    "url": "http://www.edhrec.com"
  }
]

[X]  Koppla en person till ett nytt intresse

curl -X 'PUT' \
  'https://localhost:7040/api/People/Details?personId=3&interestId=1' \
  -H 'accept: */*'

  Request URL
https://localhost:7040/api/People/Details?personId=2&interestId=1
Server response
Code	Details
200	
Response body
Download
Interest added to McGyver
Response headers
 content-type: text/plain; charset=utf-8 
 date: Fri,02 May 2025 07:22:10 GMT 
 server: Kestrel 

- [ ]  Lägga till nya länkar för en specifik person och ett specifikt intresse


curl -X 'POST' \
  'https://localhost:7040/api/Link/Details?personId=2&interestId=2' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "title": "Jula",
  "url": "http://www.jula.se"
}'

Request URL
https://localhost:7040/api/Link/Details?personId=1&interestId=1
Server response
Code	Details
200	
Response body
Download
Added
Response headers
 content-type: text/plain; charset=utf-8 
 date: Fri,02 May 2025 07:23:09 GMT 
 server: Kestrel 



