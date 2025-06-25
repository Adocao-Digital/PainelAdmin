document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("usuario").focus();
});

function toggleSenha() {
    const senhaInput = document.getElementById("senha");
    const tipo = senhaInput.getAttribute("type") === "password" ? "text" : "password";
    senhaInput.setAttribute("type", tipo);
    if (tipo === "text") {
        imgSenha.src = "img/opened-eye.png"; // Olho aberto
        imgSenha.alt = "Olho Aberto";
    } else {
        imgSenha.src = "img/closed-eye.png"; // Olho fechado
        imgSenha.alt = "Olho Fechado";
    }
}

function classeAtivo() {
    const ativo = document.getElementById("ativo");
    ativo.checked = !ativo.checked;

    const classe = ativo.checked ? "btn-success" : "btn-danger";
    ativo.className = "btn " + classe;

    const texto = ativo.checked ? "Ativo" : "Inativo";
    ativo.textContent = texto;

    return false;
}