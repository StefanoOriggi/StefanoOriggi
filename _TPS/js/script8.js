function renderHTML() {
    const htmlCode = document.getElementById('htmlInput').value;
    const newElement = document.createElement('div');
    const outputDiv = document.getElementById('output');

    newElement.innerHTML += htmlCode;
    outputDiv.appendChild(newElement);
    //document.getElementById('htmlInput').value = '';

    /*PRIMA VERSIONE
    const htmlCode = document.getElementById('htmlInput').value;
    const newElement = document.createElement('div');
    const outputDiv = document.getElementById('output');

    newElement.innerHTML += htmlCode;
    outputDiv.appendChild(newElement);
    //document.getElementById('htmlInput').value = '';
    */
}