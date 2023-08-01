function addData(event) {
    event.preventDefault();
    const name = document.getElementById("name").value;
    const type = document.getElementById("type").value;
    const photoUrl = document.getElementById("photoUrl").value;
    const description = document.getElementById("description").value;

    const dataString = `${name}\n${type}\n${photoUrl}\n${description}`;

    $.ajax({
        type: "POST", // Метод запроса (POST)
        url: "/VehicleAddition/VehicleAddButton", // URL метода контроллера
        data: JSON.stringify(dataString), // Преобразуем объект data в JSON-строку и отправляем в теле запроса
        contentType: "application/json", // Use "application/json" without the charset
        dataType: "json",
        success: function (response) {
            alert(response.message);
        },
        error: function (xhr, textStatus, errorThrown) {
            // Обработка ошибки
            alert("Ошибка при отправке данных на сервер:", errorThrown);
        }
    });
}



