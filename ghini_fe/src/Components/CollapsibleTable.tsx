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



/*
history: [
      {
        date: '2020-01-05',
        customerId: '11091700',
        amount: 3,
      },
      {
        date: '2020-01-02',
        customerId: 'Anonymous',
        amount: 1,
      },
    ],
*/

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

  var popupViews = document.querySelectorAll('.popup-view');
  var popupBtns = document.querySelectorAll('.popup-btn');
  var closeBtns = document.querySelectorAll('.close-btn');
  var addBtns = document.querySelectorAll('.add-cart-btn');

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
        <TableCell align="right">{row.status == 1 ? "Accepted" : (row.status == 2 ? "Rejected" : "Pending")}  </TableCell>
        <Button className="popup-btn" onClick={() => handleChange(row.id)}>Change</Button>
        <div className="product-card">
          <div className="product">
            <div className="popup-view">
              <div className="popup-card">
                <CloseButton />
                <div className="center4">
                  <h1> Add products</h1>
                  <form method="post">
                    {/* onSubmit={handleSubmit(onFormSubmit)} */}
                    <div className="txt_field4">
                      <input name="message" type="text"
                        asp-for="FileUpload.FormFile"
                        defaultValue="Message"
                      />

                      <span></span>
                      <label>Message</label>
                    </div>

                    <div className="txt_field">
                      {/* <input name="category" type="text" required /> */}
                      <span></span>
                      <select id="cars" name="category" className="txt_field"   >
                        <option value="1">Accept</option>
                        <option value="2">Reject</option>
                        <option value="3">Pending</option>
                      </select>
                      <label>Status</label>
                    </div>

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

const history = [
  {
    date: '2020-01-05',
    customerId: '11091700',
    amount: 3,
  },
  {
    date: '2020-01-02',
    customerId: 'Anonymous',
    amount: 1,
  },
];

const rows1 = [

  createData('Frozen yoghurt', "12.22.2022", 37, "ceva", 12, history),

];

export default function CollapsibleTable(rws: any) {

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

    var firstData = {
      address: r.address,
      date: r.date.substring(0, r.date.length - 8),
      totalCost: r.finalCost,
      id: r.id,
      name: r.name,
      telephone: r.telephoneNr,
      history: listItems,
      status: r.status
    }
    list.push(firstData);
    // console.log(r);
  });

  console.log(list, "LIST");


  return (
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
          {list.map((row) => (
            <Row key={row.id} row={row} />
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
