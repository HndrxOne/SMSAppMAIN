

function fnLogin() {

    strUsr = document.getElementById('username').value;
    strPsw = document.getElementById('password').value;

    if (strUsr !== '' && strPsw !== '') {

        let objData = {
            Usr: strUsr,
            Psw: strPsw
        }

        fnDataByFetchPostWay('User/Verication/', objData, fnValidation);

    } else {
        alert('The fields are not completed');
    }

    
}

function fnValidation(response) {

    if (response.ErrorMessage === '') {
        window.location = 'Home/Index';
    } else {
        alert(response.ErrorMessage);
    }
}

function fnDataByFetchPostWay(_url, Data, fnCallback) {

    try {

        let formData = new FormData();

        for (var property in Data) {
            formData.append(property, Data[property]);
        }

        fetch(
            _url
            , {
                method: 'POST',
                body: formData
            })
            .then(response => response.json())
            .then(data => fnCallback(data))
            .catch(error => fnMessage('Error:' + error, 2));

        return false;

    } catch (ex) {
        fnMessage(ex.message, 2);
    }
}
