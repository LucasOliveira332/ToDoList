let btn = document.getElementById('btn');
let title = document.getElementById('title');
btn.disabled = true;

function key() {
    if (title.value === '') {
        btn.disabled = true;
    }
    else {
        btn.disabled = false;
    }
}


