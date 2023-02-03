import React, { useState } from 'react';
import Button from '@mui/material/Button';

function isNumber(n) {
    return typeof n == 'number' && !isNaN(n) && isFinite(n) && n % 1 === 0;//We dont support decimals currently, prevent crashes
}

function Calculator() {
    const [displayValues, setDisplayValues] = useState({
        answerDisplay: ""
    });
    const [values, setValues] = useState({
        start: "",
        amount: "",
    });

    const getCalculation = async (type) => {
        const floatAmount = parseFloat(values.amount);
        const floatStart = parseFloat(values.start);

        let fResponse = displayValues.answerDisplay ?? "";

        if (isNumber(floatAmount) && isNumber(floatStart)) {
            const response = await fetch('calculator?start=' + floatStart + '&amount=' + floatAmount + "&operationtype=" + type);
            fResponse = await response.json();
        }

        setDisplayValues({ ...displayValues, answerDisplay: fResponse});
    }

    const handleStartChange = (event) => {
        setValues({ ...values, start: event.target.value });
    }

    const handleAmountChange = (event) => {
        setValues({ ...values, amount: event.target.value });
    }

    async function handleClick(type) {
        await getCalculation(type);
    }

    return (
        <div>
            <form>
            <p>Starting Number</p>

            <input
                type="number"
                value={values.start}
                onChange={handleStartChange}
            />

            <p>Amount</p>
            <input
                type="number"
                value={values.amount}
                onChange={handleAmountChange}
            />

            <div style={{paddingTop: "4px"}}>
            <Button onClick={async () => handleClick("add")} color="secondary" variant="contained">Add</Button>
            <Button onClick={async () => handleClick("subtract")} color="secondary" variant="contained">Subtract</Button>
            </div>

            <p> Answer: {displayValues.answerDisplay}</p>
            </form>
        </div>
    );

};

export default Calculator;
