function fullscreen() {
    //accedo agli elementi e li nascondo
    //metto in full screen main article
    const article = document.querySelector("article");
    const aside = document.querySelector("aside");
    const navBar = document.querySelector("nav");
    aside.hidden = true;
    navBar.hidden = true;
}
