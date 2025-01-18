function UpdateBillingAddress() {
    const container = document.getElementById("billingAddress");
    const checkbox = document.getElementById("differentAddress");

    if (checkbox.checked) {
        if (!container.hasChildNodes()) {
            const billingAddressHtml = `
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
                        <input type="text" name="BillingAddress.City" class="form-control">
                        <span class="text-danger field-validation-valid" data-valmsg-for="BillingAddress.City" data-valmsg-replace="true"></span>
                    </div>
                    <div class="col-md-4">
                        <label for="BillingAddress.Voivodship" class="form-label">Województwo</label>
                        <select class="form-select" id="voivodship" required>
                            <option selected value="">---Wybierz województwo---</option>
                            <option value="0">dolnośląskie</option>
                            <option value="1">kujawsko-pomorskie</option>
                            <option value="2">łódzkie</option>
                            <option value="3">lubelskie</option>
                            <option value="4">lubuskie</option>
                            <option value="5">małopolskie</option>
                            <option value="6">mazowieckie</option>
                            <option value="7">podkarpackie</option>
                            <option value="8">pomorskie</option>
                            <option value="9">śląskie</option>
                            <option value="10">warmińsko-mazurskie</option>
                            <option value="11">wielkopolskie</option>
                            <option value="12">zachodniopomorskie</option>
                            <option value="13">podlaskie</option>
                            <option value="14">świętokrzyskie</option>
                            <option value="15">opolskie</option>
                        </select>
                    </div>
                    <div class="col-md-3">
                        <label for="BillingAddress.PostalCode" class="form-label">Kod pocztowy</label>
                        <input type="text" name="BillingAddress.PostalCode" class="form-control" placeholder="np. '12-123'">
                        <span class="text-danger field-validation-valid" data-valmsg-for="BillingAddress.PostalCode" data-valmsg-replace="true"></span>
                    </div>
                </div>
            `;
            container.innerHTML = billingAddressHtml;
        }
    } else {
        container.innerHTML = "";
    }
}
