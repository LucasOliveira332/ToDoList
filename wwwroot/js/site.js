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

function Loading() {
    let request = new XMLHttpRequest()

    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            setTimeout(() => {

                document.getElementsByTagName('body').innerHTML = this.response.text


            }, 3000)

        }
    }
    request.open('GET', '/Home/IndexContent');

    request.send();

}