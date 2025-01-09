function funzione1(param1, param2, param3) {
    console.log(param1 + param2 + param3);   
}

//Posso invocare la funzione passando i parametri come valori
funzione1(5, 10, {nome: "Luigi", cognome: "Verdi"}); //15


param4 = 5;
param5 = 10; 

function funzione2(param4, param5) {
    console.log("funzione eseguita" , param4  + param5);
}

funzione2(5, 10); //15

function funzione3() {
    let paragrafo = document.getElementById("paragrafo");
    paragrafo.innerHTML = "Ciao a tutti! Questo testo è stato inserito tramite JavaScript";

    /* Per poter modificare o interagire direttamente con gli elementi HTML, è necessario utilizzare il DOM (Document Object Model). 
    Ed è un'oggetto di Javascript che contiene tutti però tutte le informazioni e i metodi utili a descrivere e interagire con la pagina HTML attualmente renderizzata. */
}

// Lista di persone
persone = [
    {nome: "Mario", cognome: "Rossi", eta: 30},
    {nome: "Luigi", cognome: "Verdi", eta: 25},
    {nome: "Giovanni", cognome: "Bianchi", eta: 35}
];

function popolaTabella() {
    let tabella = document.getElementById("tabella");

    let htmlBody = "";
    for(persona of persone) {
        htmlBody += "<tr><td>" + persona.nome + "</td><td>" + persona.cognome + "</td><td>" + persona.eta + "</td></tr>";
    }
    tabella.innerHTML = htmlBody;
}
