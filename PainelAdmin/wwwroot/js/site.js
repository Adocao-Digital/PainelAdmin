// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//document.querySelectorAll('.mostrarNoticia').forEach(icon => {
//    icon.addEventListener('click', function (e) {
//        e.stopPropagation(); 
//    });
//});

//let aberto = false;

//function alternarSeta() {
//    const seta = document.getElementById('setaNoticias');
//    seta.classList.toggle('rotate-180');
//}

//// Garante que se o collapse abrir por Bootstrap, a seta também vira
//document.addEventListener('DOMContentLoaded', function () {
//    const noticiasCollapse = document.getElementById('noticiasCollapse');
//    const seta = document.getElementById('setaNoticias');

//    if (noticiasCollapse && seta) {
//        noticiasCollapse.addEventListener('show.bs.collapse', function () {
//            seta.classList.add('rotate-180');
//        });

//        noticiasCollapse.addEventListener('hide.bs.collapse', function () {
//            seta.classList.remove('rotate-180');
//        });
//    }
//});

//    function toggleSenha(inputId, button) {
//        const input = document.getElementById(inputId);
//    const img = button.querySelector("img");

//    if (input.type === "password") {
//        input.type = "text";
//    img.src = "/img/olhos-cruzados.png";
//    img.alt = "Ocultar senha";
//        } else {
//        input.type = "password";
//    img.src = "/img/olho.png";
//    img.alt = "Mostrar senha";
//        }
//}
function toggleSidebar() {
    const sidebar = document.querySelector('.sidebar');
    sidebar.classList.toggle('show');
}