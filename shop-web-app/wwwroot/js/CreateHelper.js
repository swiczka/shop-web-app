function updateSubCategories() {
    const category = document.getElementById("categorySelect").value;
    const subCategorySelect = document.getElementById("subCategorySelect");

    subCategorySelect.innerHTML = "";

    let options = [];

    if (category === "Top") {
        options = [
            { id: "TTShirt", name: "T-shirt" },
            { id: "TShirt", name: "Koszula" },
            { id: "TLongsleeve", name: "Koszulka z długim rękawem" },
            { id: "TCrewneck", name: "Crewneck" },
            { id: "THoodie", name: "Bluza z kapturem" },
            { id: "TSweater", name: "Sweter" },
            { id: "TJacket", name: "Kurtka" },
            { id: "TCoat", name: "Płaszcz" },
            { id: "TSuit", name: "Garnitur" },
            { id: "TDress", name: "Sukienka" }
        ];
    } else if (category === "Bottom") {
        options = [
            { id: "BJeans", name: "Jeansy" },
            { id: "BTrousers", name: "Spodnie" },
            { id: "BShorts", name: "Szorty" },
            { id: "BSkirt", name: "Spódnica" },
            { id: "BLeggings", name: "Legginsy" },
            { id: "BSweatpants", name: "Dresy" }
        ];
    } else if (category === "Accessory") {
        options = [
            { id: "ABelt", name: "Pasek" },
            { id: "AHat", name: "Kapelusz" },
            { id: "AScarf", name: "Szalik" },
            { id: "AGloves", name: "Rękawiczki" },
            { id: "ASunglasses", name: "Okulary przeciwsłoneczne" },
            { id: "AWatch", name: "Zegarek" },
            { id: "ABag", name: "Torba" },
            { id: "AJewelry", name: "Biżuteria" }
        ];
    } else if (category === "Shoes") {
        options = [
            { id: "SSneakers", name: "Sneakersy" },
            { id: "SBoots", name: "Buty" },
            { id: "SSandals", name: "Sandały" },
            { id: "SLoafers", name: "Loafersy" },
            { id: "SHeels", name: "Szpilki" },
            { id: "SFlats", name: "Baleriny" },
            { id: "SSlippers", name: "Kapcie" },
            { id: "SRunningShoes", name: "Buty do biegania" },
            { id: "SWorkShoes", name: "Buty robocze" }
        ];
    }

    options.forEach(subCategory => {
        const option = document.createElement("option");
        option.value = subCategory.id;
        option.text = subCategory.name;
        subCategorySelect.appendChild(option);
    });
}


let variantIndex = 0;

function adjustVariantIndex() {
    finish = false;
    i = 0;

    while (!finish) {
        let variantDiv = document.getElementById(`variant-${i}`);
        if (variantDiv) {
            i++;
            variantIndex = i;
        }
        else {
            finish = true;
        }
    }
    console.log("Na wyjściu funkcji adjustVariantIndex: ", variantIndex);
}


function addVariant() {
    const variantContainer = document.createElement('div');
    variantContainer.id = `variant-${variantIndex}`;
    const category = document.getElementById("categorySelect").value;
    variantContainer.innerHTML = `
                <h3>Wariant ${variantIndex + 1}</h3>
                        <input type="text" name="ProductVariants[${variantIndex}].Name" placeholder="Nazwa Wariantu" class="form-control">

                <div class="photos">
                    <label>Zdjęcia:</label>
                    <input type="file" name="ProductVariants[${variantIndex}].Photos" multiple>
                </div>

                        <div id="variant-${variantIndex}-colors" class="form-group">

            <label>Kolory</label>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="Red" id="color1-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color1-variant${variantIndex}">
                    Czerwony
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="Green" id="color2-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color2-variant${variantIndex}">
                    Zielony
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="Blue" id="color3-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color3-variant${variantIndex}">
                    Niebieski
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="Yellow" id="color4-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color4-variant${variantIndex}">
                    Żółty
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="White" id="color5-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color5-variant${variantIndex}">
                    Biały
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="Black" id="color6-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color6-variant${variantIndex}">
                    Czarny
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="Gray" id="color7-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color7-variant${variantIndex}">
                    Szary
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input" type="checkbox" name="ProductVariants[${variantIndex}].Colors" value="Purple" id="color8-variant${variantIndex} onclick="setColorIndexes()">
                <label class="form-check-label" for="color8-variant${variantIndex}">
                    Fioletowy
                </label>
            </div>
            <div class="form-check">
                <input class="col-form-check-input"
                       type="checkbox"
                       name="ProductVariants[${variantIndex}].Colors" 
                       value="Pink" 
                       id="color9-variant${variantIndex}" 
                       onclick="setColorIndexes(${variantIndex})">
                <label class="form-check-label" for="color9-variant${variantIndex}">
                    Różowy
                </label>
            </div>
        </div>
                <div class="sizes">
                    <h4>Rozmiary i Ilości:</h4>
                    ${getSizeChooseHtml(category, variantIndex)}
                </div>
                <div id="removeVariant-${variantIndex}">
                </div>

                `;
    
    document.getElementById('variantsContainer').appendChild(variantContainer);
    console.log("W funkcji dodawwania: ", variantIndex);

    if (variantIndex === 0) {
        const button = document.createElement("button");
        button.type = "button";
        button.className = "btn btn-danger";
        button.id = "removeVariantButton";
        button.onclick = function () {
            removeVariant(variantIndex);
        };
        button.innerHTML = "Usuń wariant";
        document.getElementById('removeVariantContainer').appendChild(button);
    }
    else {
        const button = document.getElementById("removeVariantButton");
        button.onclick = function () {
            removeVariant(variantIndex);
        };
    }

   
    document.querySelectorAll('.col-form-check-input').forEach((checkbox) => {
        checkbox.addEventListener('click', setColorIndexes);
    });
    variantIndex++;
}

let editVariantIndex = 0;

function removeVariant(index) {
    const variantButton = document.getElementById("removeVariantButton");
    if (variantIndex === 1) {
        if (variantButton) {
            variantButton.remove();
        }
    }
    else {
        variantButton.onclick = function () {
            removeVariant(variantIndex-1);
        };
    }
    const variantDiv = document.getElementById(`variant-${variantIndex-1}`);
    if (variantDiv) {
        variantDiv.remove();
    }
    variantIndex--;
}

function getSizeChooseHtml(category, variantIndex) {
    let sizeChooseHtml = '';

    if (category === "Shoes") {
        const shoeSizes = [
            "Size35", "Size35_5", "Size36", "Size36_5", "Size37", "Size37_5",
            "Size38", "Size38_5", "Size39", "Size39_5", "Size40", "Size40_5",
            "Size41", "Size41_5", "Size42", "Size42_5", "Size43", "Size43_5",
            "Size44", "Size44_5", "Size45", "Size45_5", "Size46"
        ];
        shoeSizes.forEach((size, index) => {
            sizeChooseHtml += `
                        <label>${size.replace("Size", "")}</label>
                        <div style="display: flex; align-items: center;">
                                    <input type="hidden" name="ProductVariants[${variantIndex}].ShoeSizeQuantity[${index}].Size" value="${size}">
                                            <input type="number" name="ProductVariants[${variantIndex}].ShoeSizeQuantity[${index}].Quantity"
                                   placeholder="Ilość" class="form-control" style="width: 100px; margin-right: 8px; value="0";>
                        </div>
                    `;
        });
    } else {
        const internationalSizes = ["XS", "S", "M", "L", "XL", "XXL"];
        internationalSizes.forEach((size, index) => {
            sizeChooseHtml += `
                        <label>${size}</label>
                        <div style="display: flex; align-items: center;">
                                            <input type="hidden" name="ProductVariants[${variantIndex}].InternationalSizeQuantity[${index}].Size" value="${size}">
                                            <input type="number" name="ProductVariants[${variantIndex}].InternationalSizeQuantity[${index}].Quantity"
                                   placeholder="Ilość" class="form-control" style="width: 100px; margin-right: 8px;">
                        </div>
                    `;
        });
    }

    return sizeChooseHtml;
}



function setMaterialIndexes() {
    const checkBoxes = document.querySelectorAll('.mat-form-check-input');
    let index = 0;

    checkBoxes.forEach(checkBox => {
        if (checkBox.checked) {
            checkBox.name = `ProductMaterials[${index}].Material`;
            index++;
        }
        else {
            checkBox.name = `doesntmatter`;
        }
    });
}

function setColorIndexes() {
    
    const checkBoxes = document.querySelectorAll('.col-form-check-input');

    var index = 0;
    let varIndex = null;

    checkBoxes.forEach(checkBox => {
        const currentVarIndex = checkBox.name.split("[")[1].split("]")[0];
  
        if (varIndex !== currentVarIndex) {
            index = 0; 
            varIndex = currentVarIndex; 
        }

        console.log(varIndex);
        if (checkBox.checked) {
            checkBox.name = `ProductVariants[${varIndex}].Colors[${index}].Color`;
            console.log(checkBox.name);
            index++;
        }
        else {
            checkBox.name = `ProductVariants[${varIndex}].Colors`;
        }
    });
}