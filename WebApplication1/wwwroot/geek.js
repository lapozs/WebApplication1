var viccek;

fetch('/jokes.json')
    .then(response => response.json())
    .then(data => letöltésBefejeződött(data)
    );

function letöltésBefejeződött(d) {
    console.log("Sikeres letöltés")
    console.log(d)
    viccek = d;
}