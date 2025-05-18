function toggleSenha() {
    let senhaInput = document.getElementById("ipassword");
    let tipo = senhaInput.getAttribute("type") === "password" ? "text" : "password";
    senhaInput.setAttribute("type", tipo);
    if (tipo === "text") {
        imgSenha.src = "img/opened-eye.png"; // Olho aberto
        imgSenha.alt = "Olho Aberto";
    } else {
        imgSenha.src = "img/closed-eye.png"; // Olho fechado
        imgSenha.alt = "Olho Fechado";
    }
}

function toggleSenha2() {
    let senhaInput = document.getElementById("iconfirm");
    let tipo = senhaInput.getAttribute("type") === "password" ? "text" : "password";
    senhaInput.setAttribute("type", tipo);
    if (tipo === "text") {
        imgSenhaConfirm.src = "img/opened-eye.png"; // Olho aberto
        imgSenhaConfirm.alt = "Olho Aberto";
    } else {
        imgSenhaConfirm.src = "img/closed-eye.png"; // Olho fechado
        imgSenhaConfirm.alt = "Olho Fechado";
    }
}

document.addEventListener('DOMContentLoaded', function () {
    const senha = document.getElementById('senha');
    const confirma = document.getElementById('confirma');
    const escrita = document.getElementById('escrita');
    const form = document.querySelector('form');

    form.onsubmit = function (event) {
        // Limpar estilos e mensagens anteriores
        senha.classList.remove('input-erro');
        confirma.classList.remove('input-erro');
        escrita.textContent = '';

        // Verificar se as senhas coincidem
        if (senha.value !== confirma.value) {
            event.preventDefault(); // Impede o envio do formulário
            escrita.textContent = 'As senhas não coincidem!';
            
            // Destacar o campo com a senha incorreta
            if (!senha.value || senha.value !== confirma.value) {
                senha.classList.add('input-erro');
            }
            confirma.classList.add('input-erro');
        }
    };
});