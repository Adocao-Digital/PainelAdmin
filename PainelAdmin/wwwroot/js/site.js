// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.querySelectorAll('.mostrarNoticia').forEach(icon => {
    icon.addEventListener('click', function (e) {
        e.stopPropagation(); 
    });
});

let aberto = false;

function alternarIcone() {
    const seta = document.querySelector(".mostrarNoticia");

    if (aberto) {
        seta.src = "/img/angulo-pequeno-direito.png";
    } else {
        seta.src = "/img/angulo-pequeno-para-baixo (3).png";
    }

    aberto = !aberto;
}

    function toggleSenha(inputId, button) {
        const input = document.getElementById(inputId);
    const img = button.querySelector("img");

    if (input.type === "password") {
        input.type = "text";
    img.src = "/img/olhos-cruzados.png";
    img.alt = "Ocultar senha";
        } else {
        input.type = "password";
    img.src = "/img/olho.png";
    img.alt = "Mostrar senha";
        }
}
