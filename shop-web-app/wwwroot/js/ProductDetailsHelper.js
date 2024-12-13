const sizes = [
    { id: "1", name: "S" },
    { id: "2", name: "M" },
    { id: "3", name: "L" },
    { id: "4", name: "XL" },
    { id: "5", name: "XXL" }
];

const shoeSizes = [
    "Size35", "Size35_5", "Size36", "Size36_5", "Size37", "Size37_5",
    "Size38", "Size38_5", "Size39", "Size39_5", "Size40", "Size40_5",
    "Size41", "Size41_5", "Size42", "Size42_5", "Size43", "Size43_5",
    "Size44", "Size44_5", "Size45", "Size45_5", "Size46"
];

let currentVariantIndex = 0;

function changeVariant(thumbnail) {

    if (!thumbnail.classList.contains('selected')) {
        thumbnail.classList.toggle('selected');
    }
   
    document.querySelectorAll('.img-thumbnail').forEach((img) => {
        if (img.classList.contains('selected') && img.id !== thumbnail.id) {
            img.classList.remove('selected');
        }
    });

    currentVariantIndex = thumbnail.getAttribute("data-variant-index");

    //swap carouselContent
    const carouselContent = document.getElementById("carouselContent");
    carouselContent.innerHTML = "";

    const variant = variantData.$values[currentVariantIndex];
    const newImages = variant.photos.$values;
    let imagesHtml;

    newImages.forEach((img, index) => {
        if (index === 0) {
            imagesHtml += `<div class="carousel-item active">
                                <img alt="Image" id="mainImage" src="${img.photoUrl}" class="rounded img-fluid" style="width: 100%;" />
                            </div>`
        }
        else {
            imagesHtml += `<div class="carousel-item">
                                <img alt="Image" id="mainImage" src="${img.photoUrl}" class="rounded img-fluid" style="width: 100%;" />
                            </div>`
        }   
    });
    carouselContent.innerHTML = imagesHtml;


    //update sizes
    const sizesContainer = document.getElementById("sizesContainer");
    console.log(variant);
    sizesContainer.innerHTML = ""; 

    //jeśli nie jest butem
    if (variant.internationalSizeQuantity.$values.length != 0) {
        let sizeHtml = `<select id="selectedSize" class="form-select form-select mb-3" style="width: 180px;">
                            <option value="" selected>Wybierz rozmiar</option>`;

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
        let sizeHtml = `<select id="selectedSize" class="form-select form-select mb-3" style="width: 180px;">
                            <option value="" selected>Wybierz rozmiar</option>`;

        variant.shoeSizeQuantity.$values.forEach((sq, index) => {
            if (sq.quantity > 0) {
                sizeHtml += `<option value="${shoeSizes[index]}">${shoeSizes[index].replace("Size","").replace("_",",")}</option>`;
            }
            else {
                sizeHtml += `<option disabled class="text-muted" value="${shoeSizes[index]}">${shoeSizes[index].replace("Size", "").replace("_", ",")} (niedostępne)</option>`;
            }
        });
        sizeHtml += `</select >`;
        sizesContainer.innerHTML = sizeHtml;
    }

    //zaaktualizuj label
    const label = document.getElementById("variantName");
    label.innerHTML = `<b>Wariant: </b> ${variant.name}`;
    
}

function addToCart() {
    console.log(variantData);
    const variants = variantData.$values;
    const selectedVariantId = variants[currentVariantIndex].id;
    const selectedSize = document.getElementById("selectedSize").value;
    const selectedProductPrice = variants[currentVariantIndex].product.price;

    if (selectedVariantId && selectedSize !== "Wybierz rozmiar") {
        const cartItem = {
            ProductVariantId: selectedVariantId,
            Size: selectedSize,
            Price: selectedProductPrice,
            Quantity: 1 
        };

        let cartAlert = document.getElementById("cartAlert");
        let content = `<div class="alert alert-success alert-dismissible fade show" role="alert">
                        A simple success alert with <a href="#" class="alert-link">an example link</a>. Give it a click if you like.
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>;`

        console.log(JSON.stringify(cartItem));

        fetch("/Cart/Create", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(cartItem)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Błąd w odpowiedzi serwera");
                }
                return response.json();
            })
            .then(data => {
                if (data.success) {

                    cartAlert.innerHTML =
                        `<div class="alert alert-success alert-dismissible fade show" role="alert">
                        Dodano produkt do koszyka! <a href="/Cart" class="alert-link">Zobacz swój koszyk.</a>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`;

                } else {
                    cartAlert.innerHTML =
                        `<div class="alert alert-danger alert-dismissible fade show" role="alert">
                        Nie udało się dodać produktu do koszyka!
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`;
                }
            })
            .catch(error => {
                console.error("Błąd:", error);
                cartAlert.innerHTML =
                    `<div class="alert alert-danger alert-dismissible fade show" role="alert">
                        Nie udało się dodać produktu do koszyka!
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`;
            });
    } else {
        cartAlert.innerHTML =
            `<div class="alert alert-danger alert-dismissible fade show" role="alert">
                        Należy wybrać wariant oraz rozmiar produktu.
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>`;
    }
}
