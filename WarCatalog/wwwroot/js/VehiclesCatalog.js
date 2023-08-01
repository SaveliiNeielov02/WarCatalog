function onHover(vehicleID, element, typeID)
{
    var headerDiv = document.getElementById(vehicleID.toString());
    if (headerDiv.childElementCount < 2) {
        var removingHeader = document.createElement('h2');
        removingHeader.textContent = 'Delete';
        var link = document.createElement('a');
        link.href = '/VehiclesCatalog/DeleteVehicle/' + vehicleID + '/' + typeID; 
        link.appendChild(removingHeader);
        headerDiv.appendChild(link);
        element.addEventListener('mouseleave', removeHeader);

        function removeHeader(event) {
            if (!is_cursor_on_elem(event, link)) {
                headerDiv.removeChild(link);
                element.removeEventListener('mouseleave', removeHeader);
            }
        }
    }
}

function is_cursor_on_elem(ev, elem) {
    let mouseX = ev.clientX;
    let mouseY = ev.clientY;
    let rect = elem.getBoundingClientRect();

    return (
        mouseX > rect.x && mouseX < rect.right &&
        mouseY > rect.y && mouseY < rect.bottom
    );
}





