/*
UTENTI
+----------------+--------------+--------------------------+
|      CF        |     nome     |       luogo_nascita      |
+----------------+--------------+--------------------------+
|   MRCRM02100   |     Marco    |         RM               |
+----------------+--------------+--------------------------+
|   NNVT03150    |      Anna    |         NA               |
------------------------------------------------------------
*/


/*crea la tabella UTENTI*/
CREATE TABLE UTENTI(
  CF varchar(255) NOT NULL,
  nome varchar(255),
  luogo_nascita varchar(255),
  PRIMARY KEY (CF)
);

/*seleziona tutte le ennuple della tabella UTENTI*/
SELECT *
FROM UTENTI;

/*inserisce nella tabella UTENTI la ennupla <MRCRM02100, Marco, RM>*/
INSERT INTO UTENTI
VALUES ('MRCRM02100', 'Marco', 'RM');

/*inserisce nella tabella UTENTI la ennupla <NNVT03150, Anna, NA>*/
INSERT INTO UTENTI
VALUES ('NNVT03150', 'Anna', 'NA');

/*seleziona tutte le ennuple della tabella UTENTI*/
SELECT *
FROM UTENTI;

/*
QUERY CON ERRORE: provo a inserire una ennupla con chiave uguale a una già presente
*/
INSERT INTO UTENTI
VALUES ('NNVT03150', 'Alessia', 'RI');

/*
QUERY CON ERRORE: provo a inserire una ennupla ma non specifico la chiave
*/
INSERT INTO UTENTI (nome, luogo_nascita)
VALUES ('Alessia', 'RI');


/*
PROVINCE
+--------------------+-----------------------+--------------------+
|      codice        |     nome_completo     |        regione     |
+--------------------+-----------------------+--------------------+
|        RM          |          Roma         |        Lazio       |
+--------------------+-----------------------+--------------------+
|        NA          |         Napoli        |       Campania     |
-------------------------------------------------------------------
*/

/*crea la tabella PROVINCE*/
CREATE TABLE PROVINCE(
  codice varchar(255) NOT NULL,
  nome_completo varchar(255),
  regione varchar(255),
  PRIMARY KEY (codice)
);

/*inserisce nella tabella PROVINCE la ennupla <RM, Roma, Lazio>*/
INSERT INTO PROVINCE
VALUES ('RM', 'Roma', 'Lazio');

/*inserisce nella tabella PROVINCE la ennupla <NA, Napoli, Campania>*/
INSERT INTO PROVINCE
VALUES ('NA', 'Napoli', 'Campania');

/*
esempio JOIN
seleziona tutte le ennuple che derivano dal join tra PROVINCE e UTENTI sulla condizione luogo nascita
*/
SELECT *
FROM PROVINCE JOIN UTENTI
              ON luogo_nascita=codice

/*
esempio JOIN
seleziona tutte le ennuple che derivano dal join tra PROVINCE e UTENTI sulla condizione luogo nascita
stampa solo il codice fiscale e il nome della regione
*/
SELECT CF, regione
FROM PROVINCE JOIN UTENTI
              ON luogo_nascita=codice

/*
esempio PRODOTTO CARTESIANO
seleziona tutte le ennuple che derivano dal prodotto cartesiano PROVINCE X UTENTI
*/
SELECT *
FROM PROVINCE, UTENTI

/*prodotto cartesiano equivalente al primo join*/
SELECT *
FROM PROVINCE, UTENTI
WHERE luogo_nascita=codice

/*prodotto cartesiano equivalente al secondo join*/
SELECT CF, regione
FROM PROVINCE, UTENTI
WHERE luogo_nascita=codice


/*
======================================================
======================================================

UTENTI
+---------------+--------------------+-----------------+-----------------+
|     CODICE    |        nome        |       prezzo    |     tipologia   |
+---------------+--------------------+-----------------+-----------------+
|      01       |        AX 23       |       80        |      mouse      |
+---------------+--------------------+-----------------+-----------------+
|      02       |        LEP 13      |       620       |      laptop     |
+---------------+--------------------+-----------------+-----------------+
|      03       |       LEP 14U      |       725       |      laptop     |
+---------------+--------------------+-----------------+-----------------+
|      04       |       TOUCH 12     |       50        |     tastiera    |
+---------------+--------------------+-----------------+-----------------+
|      05       |      INK BASIC     |       125       |    stampante    |
+---------------+--------------------+-----------------+-----------------+
|      06       |       INK PRO      |       200       |    stampante    |
+---------------+--------------------+-----------------+-----------------+
|      07       |     CLICK ONE      |       15        |      mouse      |
--------------------------------------------------------------------------
*/

/*crea la tabella PRODOTTI*/
CREATE TABLE PRODOTTI(
  codice int NOT NULL,
  nome varchar(255),
  prezzo int,
  tipologia varchar(255),
  PRIMARY KEY (codice)
);


/* popola la relazione PRODOTTI */ 
INSERT INTO PRODOTTI
VALUES (01, 'AX 23', 80, 'mouse');

INSERT INTO PRODOTTI
VALUES (02, 'LEP 13', 620, 'laptop');

INSERT INTO PRODOTTI
VALUES (03, 'LEP 14U', 725, 'laptop');

INSERT INTO PRODOTTI
VALUES (04, 'TOUCH 12', 50, 'tastiera');

INSERT INTO PRODOTTI
VALUES (05, 'INK BASIC', 125, 'stampante');

INSERT INTO PRODOTTI
VALUES (06, 'INK PRO', 200, 'stampante');

INSERT INTO PRODOTTI
VALUES (07, 'CLICK ONE', 15, 'mouse');



/*
===============
    COUNT
===============
*/
/* restituice il numero di prodotti (il numero di ennuple) */
SELECT COUNT(*)
FROM prodotti;

/* restituice il numero di prodotti che hanno un prezzo maggiore di 600 */
SELECT COUNT(*)
FROM prodotti
WHERE prezzo>600;


/*
===============
      AVG
===============
*/
/* restituisce la media dei prezzi */
SELECT AVG(prezzo)
FROM prodotti;

/* restituisce quanto costa in media una stampante*/
SELECT AVG(prezzo)
FROM prodotti
WHERE tipologia='stampante'



/*
===============
   MAX e MIN
===============
*/
/* restituisce il prezzo minore*/
SELECT MIN(prezzo)
FROM prodotti

/* restituisce il prodotto che ha prezzo minore*/
SELECT *
FROM PRODOTTI
WHERE prezzo = (SELECT MIN(prezzo)
               FROM PRODOTTI)



/*
===============
      SUM
===============
*/
/* restituisce la somma dei prezzi*/
SELECT SUM(prezzo)
FROM PRODOTTI




/*
===============
    GROUP BY
===============

/*
per ogni tipologia conta il numero di prodotti e la relativa media
*/
SELECT tipologia, COUNT(*) as numero_prodotti, AVG(prezzo) as prezzo_medio
FROM prodotti
GROUP BY tipologia