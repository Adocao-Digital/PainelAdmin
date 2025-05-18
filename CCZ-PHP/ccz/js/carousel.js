const radios = document.querySelectorAll('input[name="slide"]');
let currentIndex = 0;

function changeInput(index) {
    radios[index].checked = true;
}

setInterval(() => {
    currentIndex = (currentIndex + 1) % radios.length;
    changeInput(currentIndex);
}, 3000); // 3000 ms = 3 segundos