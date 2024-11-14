sizes = [
    { id: "1", name: "S" },
    { id: "2", name: "M" },
    { id: "3", name: "L" },
    { id: "4", name: "XL" },
    { id: "5", name: "XXL" }
];

shoeSizes = [
    { id: "1", name: "S" },
    { id: "2", name: "M" },
    { id: "3", name: "L" },
    { id: "4", name: "XL" },
    { id: "5", name: "XXL" }
];


// Funkcja, która zmienia główny obrazek i dostępne rozmiary.
function changeVariant(thumbnail) {
    // Pobranie id wariantu z klikniętej miniaturki.
    const variantIndex = thumbnail.getAttribute("data-variant-index");

    // Znajdź element głównego obrazka i zaktualizuj jego `src`.
    const mainImage = document.getElementById("mainImage");

    const variant = variantData.$values[variantIndex];

    mainImage.src = variant.photos.$values[0].photoUrl;

    // Aktualizacja dostępnych rozmiarów.
    const sizesContainer = document.getElementById("sizesContainer");
    console.log(variant);
    sizesContainer.innerHTML = ""; // Wyczyść poprzednie rozmiary

    //jeśli nie jest butem
    if (variant.internationalSizeQuantity.$values.length != 0) {
        let sizeHtml = `<select class="form-select form-select mb-3" style="width: 180px;">
                            <option selected>Wybierz rozmiar</option>`;

        variant.internationalSizeQuantity.$values.forEach(sq => {
     
            if (sq.quantity > 0) {
                sizeHtml += `<option value="${sq.size}">${sizes[sq.size - 1].name}</option>`;
            }
            else {
                sizeHtml += `<option disabled class="text-muted" value="${sq.size}">${sizes[sq.size - 1].name} (niedostępne)</option>`;  
            }
        });
        sizeHtml += `</select >`;
        sizesContainer.innerHTML = sizeHtml;
    }
    //jest butem
    else {
        let sizeHtml = `<select class="form-select form-select mb-3" style="width: 180px;">
                            <option selected>Wybierz rozmiar</option>`;

        variant.internationalSizeQuantity.$values.forEach(sq => {

            if (sq.quantity > 0) {
                sizeHtml += `<option value="${sq.size}">${sizes[sq.size - 1].name}</option>`;
            }
            else {
                sizeHtml += `<option disabled class="text-muted" value="${sq.size}">${sizes[sq.size - 1].name} (niedostępne)</option>`;
            }
        });
        sizeHtml += `</select >`;
        sizesContainer.innerHTML = sizeHtml;
    }

    //// Dodaj nowe rozmiary na podstawie wybranego wariantu
    
}
