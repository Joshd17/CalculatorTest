import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import { MuiColorInput } from 'mui-color-input'
import { default as Calculator } from "./Calculator";

function GetCalc() {
    const [backColor, setBackColor] = useState('#4B0C92')
    const [textColor, setTextColor] = useState('#ffffff')

    const handleBackColorChange = (color) => {
        setBackColor(color)
    }

    const handleTextColorChange = (color) => {
        setTextColor(color)
    }

    const style = {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        minWidth: 300,
        maxWidth: 400,

        bgcolor: 'background.paper',
        border: '2px solid #000',
        boxShadow: 24,
      };

      const wrapperStyle = {
        padding: "2px"
      };

    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    return (
        <div style={style}>

        <Button onClick={handleOpen}>Open Calculator</Button>
            <Modal
            open={open}
            onClose={handleClose}
            aria-labelledby="calculator"
            aria-describedby="calculator"
            >

            <Box sx={style}>
                <div style={{backgroundColor: backColor, width:"100%"}} >
                    <h3 style={{color: textColor}}> Simple Calculator</h3>
                </div>

                <div style={wrapperStyle}>

            <Calculator />

            </div>
            <div style={{backgroundColor: backColor, width:"100%", height:"5px"}} >
            </div>
            </Box>
            </Modal>
            <div>
                <p>Customize background color</p>
                <MuiColorInput value={backColor} onChange={handleBackColorChange} />

                <p>Customize text color</p>
                <MuiColorInput value={textColor} onChange={handleTextColorChange} />
            </div>

        </div>
    );

};

export default GetCalc;
