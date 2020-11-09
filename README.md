# UFTStest1
Test til UFTS
1. Step: Hvad skal du have i din PC før du starter
Du skal have docker desktop intalleret og kørende.
Dan en repository i din computer
Åben Developer PowerShell Visual Studio Community 2019 fra din repository

2. Step: Hent image og kør
#Fin din docker version
docker --version

#Se de images der findes i din Pc
docker images

#Hent docker images fra docker hub:
docker pull mokdocker/uftstest1:MamadouKeita

#Kontrollér at du har modtaget images:
docker images

#Build image:
docker build -t mokdocker/uftstest1

#Kør image i din PC port 8080: Map port 80 i mage til 8080 i local PC
docker run -p 8080:80 uftstest1

3. Step: Test via ReadyAPI
Åben SoapUI/ReadyAPI
Importér projekt - xml er medsendt
Kør testen.

Evt. åben Chrome browser og indtast:
http://localhost:8080/api/numbertotext/47.50
http://localhost:8080/api/numbertotext/5
http://localhost:8080/api/numbertotext/205.31
http://localhost:8080/api/numbertotext/4000.0
http://localhost:8080/api/numbertotext/1.01

4. Step: Test via Visual Studio 2019 (community edition)
Hent projekt i github - (ikke private) https://github.com/mkeit/UFTStest1
Unzip projekt
Build projekt - UFTStest1
Valg chrome browser
Kør projekt UFTStest1 i chrome browser - F5
Der åbner en Chrome browser med url f.eks.: https://localhost:5001/api/numbertotext
Tilføj et af nedenstående til url og så "Enter": 
/47.50
/5
/205.31
/4000.0
/1.01
Der kommer en Json tekst retur
