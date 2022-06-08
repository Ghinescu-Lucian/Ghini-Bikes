import * as React from 'react';
import Box from '@mui/material/Box';
import Collapse from '@mui/material/Collapse';
import IconButton from '@mui/material/IconButton';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import KeyboardArrowDownIcon from '@material-ui/icons/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@material-ui/icons/KeyboardArrowUp';
import { Avatar } from "@material-ui/core";
import Button from "@material-ui/core/Button";
import { CloseButton } from './CloseButton';
import "./CSS/CollapsibleTable.css";
import { useForm } from "react-hook-form";
import { useEffect, useState } from "react"
import * as orderService from '../Services/OrderService.js';
import SearchIcon from "@material-ui/icons/Search";


function createData(
  id: string,
  date: string,
  noItems: number,
  pay: string,
  price: number,
  history: any,
) {
  return {
    id,
    date,
    noItems,
    pay,
    price,
    history

  };
}

function Row(props: { row: any }) {
  const { row } = props;
  const [open, setOpen] = React.useState(false);

 
 
  return (
    <React.Fragment>
      <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>
        <TableCell component="th" scope="row">
          {row.id}
        </TableCell>
        <TableCell align="right">{row.date}</TableCell>
        <TableCell align="right">{row.name}</TableCell>
        <TableCell align="right">{row.totalCost}</TableCell>
        <TableCell align="right">{row.status}  </TableCell>
       
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
                Date: {row.date}
              </Typography>
              <Typography variant="h6" gutterBottom component="div">
                Address: {row.address}
              </Typography>
              <Typography variant="h6" gutterBottom component="div">
                Telephone: {row.telephone}
              </Typography>
              <Typography variant="h6" gutterBottom component="div">
                Message: {row.message}
              </Typography>
              <Typography variant="h6" gutterBottom component="div">
                Products:
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>Product ID</TableCell>
                    <TableCell align="right">Manufacturer</TableCell>
                    <TableCell align="right">Model</TableCell>
                    <TableCell align="right">Year</TableCell>
                    <TableCell align="right">Quantity</TableCell>
                    <TableCell align="right">Total price (RON)</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row.history.map((historyRow: any) => (
                    <TableRow key={historyRow.manufacturer}>
                      <TableCell>{historyRow.productId} <Avatar src={historyRow.images} /></TableCell>
                      <TableCell align="right">{historyRow.manufacturer}</TableCell>
                      <TableCell align="right">{historyRow.model}</TableCell>
                      <TableCell align="right">{historyRow.year}</TableCell>
                      <TableCell align="right">{historyRow.quantity}</TableCell>
                      <TableCell align="right">
                        {Math.round(historyRow.quantity * historyRow.price * 100) / 100}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </React.Fragment>
  );
}



export default function CollapsibleTable(rws: any) {


  const { register, handleSubmit, reset, formState: { errors }, watch } = useForm();

//   console.log(rws);



  let list: any[] = [];

  rws.rws.map((r: any) => {
    var listItems: any[] = [];
    r.items.map((r1: any) => {

      var aux = {
        productId: r1.productId,
        price: r1.price,
        manufacturer: r1.manufacturer,
        model: r1.model,
        quantity: r1.quantity,
        year: r1.year,
        images: r1.image
      };
      listItems.push(aux);

    })

    
    if (r.status == 1) r.status = "Accepted";
    else if (r.status == 2) r.status = "Rejected";
    else if (r.status == 3) r.status = "Pending";
  

    var firstData = {
      address: r.address,
      date: r.date.substring(0, r.date.length - 8),
      totalCost: r.finalCost,
      id: r.id,
      name: r.name,
      telephone: r.telephoneNr,
      history: listItems,
      status: r.status,
      message: r.message
    }
    list.push(firstData);
    // console.log(r);
  });


  const [searchTerm, setSearchTerm] = useState("")

  const onFormSubmit2 = async (data: any) => {

    var keyword = data.keyword;
    setSearchTerm(keyword);


  }
  let list2 = list.filter((val) => {
    if (val.name.toLowerCase().includes(searchTerm.toLowerCase())) {
      return val;
    }
    else if (searchTerm == "") {
      return val;
    }

  });
  // console.log("LIST", list2);


//   console.log(list, "LIST");


  return (<div>
    <form onSubmit={handleSubmit(onFormSubmit2)}>
      <div className="wrapper">
        <div className="search-input">
          <a href="" target="_blank" hidden></a>
          <input type="text" placeholder="Order ID" {...register("keyword")} />
          <div className="autocom-box">

          </div>
          {/* <div className="icon"><button type="submit" className="fas fa-search"></button></div> */}
          <Button type="submit" style={{
            position: "absolute",
            top: "10%",
            left: "85%"

          }}><SearchIcon className="icon" style={{ height: "40px", width: "40px" }} /></Button>
        </div>
      </div>
    </form>
    <span>-</span>

    <TableContainer component={Paper}>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Order ID</TableCell>
            <TableCell align="right">Date</TableCell>
            <TableCell align="right">Name</TableCell>
            <TableCell align="right">Total&nbsp;(RON)</TableCell>
            <TableCell align="right">Status</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {list.filter((val) => {
            // console.log(val.id,"ID");
            // || val.id.includes(searchTerm)
            if (val.name.toLowerCase().includes(searchTerm.toLowerCase()) || val.id.toString().includes(searchTerm) || val.status === searchTerm) {
              return val;
            }
            else if (searchTerm == "") {
              return val;
            }

          }).map((row) => (
            <Row key={row.id} row={row} />
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  </div>
  );
}

