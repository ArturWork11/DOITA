using Costruttori;

//ho creato un'oggetto chiamato videogioco che è di tipo Videogame
//quindi avrà tutte le proprietà e tutti i metodi in essa descritti
Videogame videogioco = new Videogame();
//solo a questo punto esiste il campo o la proprietà titolo
//Videogame --> è la CLASSE, la classe è astratta per cui non ha un titolo preciso e non posso accedere al campo titolo  
//videogioco --> è l'oggetto, è concreto e ha un titolo, titolo è una sua proprietà
videogioco.titolo = "Sonic Mania";