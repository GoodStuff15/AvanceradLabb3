Anrop:

- [X]  Hämta alla personer i systemet

curl -X 'GET' \
  'https://localhost:7040/api/People' \
  -H 'accept: text/plain'

- [X]  Hämta alla intressen kopplade till en specifik person

curl -X 'GET' \
  'https://localhost:7040/api/Interest/Details?personId=2' \
  -H 'accept: text/plain'

- [X]  Hämta alla länkar kopplade till en specifik person
curl -X 'GET' \
  'https://localhost:7040/api/Link/Details?personId=2' \
  -H 'accept: text/plain'

[X]  Koppla en person till ett nytt intresse

curl -X 'PUT' \
  'https://localhost:7040/api/People/Details?personId=3&interestId=1' \
  -H 'accept: */*'

- [ ]  Lägga till nya länkar för en specifik person och ett specifikt intresse

curl -X 'POST' \
  'https://localhost:7040/api/Link/Details?personId=2&interestId=2' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "title": "Jula",
  "url": "http://www.jula.se"
}'





