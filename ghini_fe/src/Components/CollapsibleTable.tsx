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
  const [token, setToken] = useState("");


  const { register, handleSubmit, reset, formState: { errors }, watch } = useForm();

  var popupViews = document.querySelectorAll('.popup-view');
  var popupBtns = document.querySelectorAll('.popup-btn');
  var closeBtns = document.querySelectorAll('.close-btn5');

  useEffect(() => {
    setToken(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user") || "{}").token : "user");
  }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user") || "{}").username : "user"]
  );

  //javascript for quick view button
  var popup = function (popupClick: any) {
    popupViews[popupClick].classList.add('active');
  }

  popupBtns.forEach((popupBtn, i) => {
    popupBtn.addEventListener("click", () => {
      popup(i);
    });
  });

  closeBtns.forEach((closeBtn) => {
    closeBtn.addEventListener("click", () => {
      popupViews.forEach((popupView) => {
        popupView.classList.remove('active');
      });
    });
  });


  const handleChange = (id: number) => {
    console.log(id);
  }

  const onFormSubmit = async (data: any) => {
    console.log(data);
    try {
      var update_Result = await orderService.UpdateOrder(data, token);
    }
    catch (err) {
      console.log("Something went wrong", err);
      alert("Something went wrong!");
    }
    if (update_Result >= 200 && update_Result < 210) {
      alert("Order edited with success!")
      window.location.reload();
    }
    else alert("Something went wrong!");
  }

 
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
        <Button className="popup-btn" onClick={() => handleChange(row.id)}>Change</Button>
        <div className="product-card">
          <div className="product">
            <div className="popup-view">
              <div className="popup-card">
                <button className="close-btn5">&times;</button>
                <div className="center4">
                  <h1> Add products</h1>
                  <form onSubmit={handleSubmit(onFormSubmit)} method="post">
                    {/* onSubmit={handleSubmit(onFormSubmit)} */}
                    <div className="txt_field4">
                      <input type="text"
                        asp-for="FileUpload.FormFile"
                        defaultValue="Message"
                        {...register("message")}
                      />

                      <span></span>
                      <label>Message</label>
                    </div>

                    <div className="txt_field">
                      {/* <input name="category" type="text" required /> */}
                      <span></span>
                      <select id="cars" className="txt_field"  {...register("status")}  >
                        <option value="1">Accept</option>
                        <option value="2">Reject</option>
                        <option value="3">Pending</option>
                      </select>
                      <label>Status</label>
                    </div>
                    <input type="hidden" value={row.id} {...register("id")} />
                    <input type="submit" name="submit" value="Save" />
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
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

  // console.log(rws);



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


  // console.log(list, "LIST");


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
