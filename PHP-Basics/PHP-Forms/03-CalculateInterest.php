<!DOCTYPE html>
<html>
<head>
    <title>Calculate Interest</title>
</head>
<body>
    <form>
        Enter Amount
        <input type="text" name="amount"/><br>
        <input type="radio" name="currency" value="$"/>USD
        <input type="radio" name="currency" value="EUR"/>EUR
        <input type="radio" name="currency" value="BGN"/>BGN<br>
        Compound Interest Amount
        <input type="text" name="interest"/><br>
        <select name="period">
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="72">5 Years</option>
        </select>
        <input type="submit" value="Calculate"/>
        <?php
        if (isset($_GET['amount']) && isset($_GET['currency'])
                && isset($_GET['interest']) && isset($_GET['period'])) {
            $result = $_GET['amount'];
            $interestPerMonth = $_GET['interest'] / 100 / 12;
            for ($i = 0; $i < $_GET['period']; $i++) {
                $result += $interestPerMonth * $result;
            }
            echo $_GET['currency'] . ' ' . round($result, 2);
        }
        ?>
    </form>
</body>
</html>