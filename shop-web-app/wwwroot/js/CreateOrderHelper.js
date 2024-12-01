function UpdateBillingAddress() {
    const container = document.getElementById("billingAddress");

    console.log(container.childNodes.length);
    if (container.hasChildNodes()) {
        container.innerHTML = "";
        return;
    }

    billingAddressHtml =
        `
            <h4 class="mb-3">Adres rozliczeniowy</h4>
            <div class="row g-3">
                <div class="col-sm-6">
                    <label for="BillingName" class="form-label">Imię</label>
                    <input type="text" name="BillingName" class="form-control" placeholder="Wprowadź imię">
                    <span class="text-danger field-validation-valid" data-valmsg-for="BillingName" data-valmsg-replace="true"></span>
                </div>

                <div class="col-sm-6">
                    <label for="BillingSurname" class="form-label">Nazwisko</label>
                    <input type="text" name="BillingSurname" class="form-control" placeholder="Wprowadź nazwisko">
                    <span class="text-danger field-validation-valid" data-valmsg-for="BillingSurname" data-valmsg-replace="true"></span>
                </div>

                <div class="col-12">
                    <label for="BillingAddress.Street" class="form-label">Adres (ulica i numer domu)</label>
                    <input type="text" name="BillingAddress.Street" class="form-control" placeholder="np.'ul. Parkowa 1/3'">
                    <span class="text-danger field-validation-valid" data-valmsg-for="BillingAddress.Street" data-valmsg-replace="true"></span>
                </div>

                <div class="col-md-5">
                    <label for="BillingAddress.City" class="form-label">Miasto</label>
                    <input type="text" name="DeliveryAddress.City" class="form-control">
                    <span class="text-danger field-validation-valid" data-valmsg-for="BillingAddress.City" data-valmsg-replace="true"></span>
                </div>

                <div class="col-md-4">
                    <label asp-for="BillingAddress.Voivodship" class="form-label">Województwo</label>
                    <select class="form-select" id="voivodship" required>
                        <option selected value="">---Wybierz województwo---</option>
                        <option value="0">dolno&#x15B;l&#x105;skie</option>
                        <option value="1">kujawsko-pomorskie</option>
                        <option value="2">&#x142;&#xF3;dzkie</option>
                        <option value="3">lubelskie</option>
                        <option value="4">lubuskie</option>
                        <option value="5">ma&#x142;opolskie</option>
                        <option value="6">mazowieckie</option>
                        <option value="7">podkarpackie</option>
                        <option value="8">pomorskie</option>
                        <option value="9">&#x15B;l&#x105;skie</option>
                        <option value="10">warmi&#x144;sko-mazurskie</option>
                        <option value="11">wielkopolskie</option>
                        <option value="12">zachodnio-pomorskie</option>
                        <option value="13">podlaskie</option>
                        <option value="14">&#x15B;wi&#x119;tokrzyskie</option>
                        <option value="15">opolskie</option>
                    </select>
                </div>

                <div class="col-md-3">
                    <label for="BillingAddress.PostalCode" class="form-label">Kod pocztowy</label>
                    <input type="text" name="DeliveryAddress.PostalCode" class="form-control" placeholder="np. '12-123'">
                    <span class="text-danger field-validation-valid" data-valmsg-for="BillingAddress.PostalCode" data-valmsg-replace="true"></span>
                </div>
            </div>
        `;
    container.innerHTML = billingAddressHtml;
      
}