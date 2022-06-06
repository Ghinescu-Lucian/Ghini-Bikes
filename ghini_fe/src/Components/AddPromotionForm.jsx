import * as React from 'react';
import { useEffect, useState } from "react"
import * as bikeService from '../Services/BikeService.js';
import PropTypes from 'prop-types';
import { alpha } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import TableSortLabel from '@mui/material/TableSortLabel';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import Switch from '@mui/material/Switch';
//'@mui/icons-material/Delete';
//'@mui/icons-material/FilterList';
import { visuallyHidden } from '@mui/utils';
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from '@hookform/resolvers/yup';
import "./CSS/DataTable.css";
import * as partService from '../Services/PartService.js';
import * as accessoryService from '../Services/AccessoryService.js';
import * as promotionService from '../Services/PromotionService.js';







function descendingComparator(a, b, orderBy) {
    if (b[orderBy] < a[orderBy]) {
        return -1;
    }
    if (b[orderBy] > a[orderBy]) {
        return 1;
    }
    return 0;
}

function getComparator(order, orderBy) {
    return order === 'desc'
        ? (a, b) => descendingComparator(a, b, orderBy)
        : (a, b) => -descendingComparator(a, b, orderBy);
}

// This method is created for cross-browser compatibility, if you don't
// need to support IE11, you can use Array.prototype.sort() directly
function stableSort(array, comparator) {
    const stabilizedThis = array.map((el, index) => [el, index]);
    stabilizedThis.sort((a, b) => {
        const order = comparator(a[0], b[0]);
        if (order !== 0) {
            return order;
        }
        return a[1] - b[1];
    });
    return stabilizedThis.map((el) => el[0]);
}

const headCells = [
    {
        id: 'id',
        numeric: false,
        disablePadding: true,
        label: 'Product ID',
    },
    {
        id: 'manufacturer',
        numeric: true,
        disablePadding: true,
        label: 'Manufacturer',
    },
    {
        id: 'Model',
        numeric: true,
        disablePadding: true,
        label: 'Model',
    },
    {
        id: 'Year',
        numeric: true,
        disablePadding: false,
        label: 'Year',
    },


];

function EnhancedTableHead(props) {
    const { onSelectAllClick, order, orderBy, numSelected, rowCount, onRequestSort } =
        props;
    const createSortHandler = (property) => (event) => {
        onRequestSort(event, property);
    };

    return (
        <TableHead>
            <TableRow>
                <TableCell padding="checkbox">
                    <Checkbox
                        color="primary"
                        indeterminate={numSelected > 0 && numSelected < rowCount}
                        checked={rowCount > 0 && numSelected === rowCount}
                        onChange={onSelectAllClick}
                        inputProps={{
                            'aria-label': 'select all desserts',
                        }}
                    />
                </TableCell>
                {headCells.map((headCell) => (
                    <TableCell
                        key={headCell.id}
                        align={headCell.numeric ? 'right' : 'left'}
                        padding={headCell.disablePadding ? 'none' : 'normal'}
                        sortDirection={orderBy === headCell.id ? order : false}
                    >
                        <TableSortLabel
                            active={orderBy === headCell.id}
                            direction={orderBy === headCell.id ? order : 'asc'}
                            onClick={createSortHandler(headCell.id)}
                        >
                            {headCell.label}
                            {orderBy === headCell.id ? (
                                <Box component="span" sx={visuallyHidden}>
                                    {order === 'desc' ? 'sorted descending' : 'sorted ascending'}
                                </Box>
                            ) : null}
                        </TableSortLabel>
                    </TableCell>
                ))}
            </TableRow>
        </TableHead>
    );
}

EnhancedTableHead.propTypes = {
    numSelected: PropTypes.number.isRequired,
    onRequestSort: PropTypes.func.isRequired,
    onSelectAllClick: PropTypes.func.isRequired,
    order: PropTypes.oneOf(['asc', 'desc']).isRequired,
    orderBy: PropTypes.string.isRequired,
    rowCount: PropTypes.number.isRequired,
};

const EnhancedTableToolbar = (props) => {
    const { numSelected, tip } = props;
    // console.log("TIP:",props);
    return (
        <Toolbar
            sx={{
                pl: { sm: 2 },
                pr: { xs: 1, sm: 1 },
                ...(numSelected > 0 && {
                    bgcolor: (theme) =>
                        alpha(theme.palette.primary.main, theme.palette.action.activatedOpacity),
                }),
            }}
        >
            {numSelected > 0 ? (
                <Typography
                    sx={{ flex: '1 1 100%' }}
                    color="inherit"
                    variant="subtitle1"
                    component="div"
                >
                    {numSelected} selected
                </Typography>
            ) : (
                <Typography
                    sx={{ flex: '1 1 100%' }}
                    variant="h6"
                    id="tableTitle"
                    component="div"
                >
                    {
                        (tip === 1) ? (<p>Bikes </p>) : ((tip === 2) ? (<p>Parts </p>) : (<p>Accessory </p>))

                    }
                </Typography>
            )}

           
        </Toolbar>
    );
};

EnhancedTableToolbar.propTypes = {
    numSelected: PropTypes.number.isRequired,
};

const schema = yup.object()
    .shape({
        name: yup.string().required(),
        file: yup.mixed().required('File is required'),

    })
    .required();

export default function EnhancedTable2() {
    const [order, setOrder] = React.useState('asc');
    const [orderBy, setOrderBy] = React.useState('calories');
    const [selected, setSelected] = React.useState([]);
    const [page, setPage] = React.useState(0);

    const [order2, setOrder2] = React.useState('asc');
    const [orderBy2, setOrderBy2] = React.useState('calories');
    const [selected2, setSelected2] = React.useState([]);
    const [page2, setPage2] = React.useState(0);

    const [order3, setOrder3] = React.useState('asc');
    const [orderBy3, setOrderBy3] = React.useState('calories');
    const [selected3, setSelected3] = React.useState([]);
    const [page3, setPage3] = React.useState(0);

    const [dense, setDense] = React.useState(false);

    const [rowsPerPage, setRowsPerPage] = React.useState(5);
    const [rowsPerPage2, setRowsPerPage2] = React.useState(5);
    const [rowsPerPage3, setRowsPerPage3] = React.useState(5);

    const [bikes, setBikes] = useState([]);
    const [parts, setParts] = useState([]);
    const [accessories, setAccessories] = useState([]);
    const [token, setToken] = useState("");
    const [file, setFile] = useState("");

    const { register, handleSubmit, reset, formState: { errors }, watch } = useForm(
        {
            resolver: yupResolver(schema)
        });


    const saveFile = (e) => {
        setFile(e.target.files[0]);
    }

    useEffect(() => {
        setToken(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).token : "user");
    }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
    );

    const bikeProducts = async () => {
        const response = await bikeService.GetBikes();
        let aux = [];
        response.map((a) => {
            var aju = {
                productId: a.productId,
                manufacturer: a.manufacturer,
                model: a.model,
                year: a.year,
                quantity: 1,
                discount: 0,
                category: a.category

            }
            aux.push(aju);
        })
        setBikes(aux);

    }
    const partProducts = async () => {
        const response = await partService.GetParts();
        let aux = [];
        response.map((a) => {
            var aju = {
                productId: a.productId,
                manufacturer: a.manufacturer,
                model: a.model,
                year: a.year,
                quantity: 1,
                discount: 0,
                category: a.category

            }
            aux.push(aju);
        })
        setParts(aux);

    }
    const accessoryProducts = async () => {
        const response = await accessoryService.GetAccessories();
        let aux = [];
        response.map((a) => {
            var aju = {
                productId: a.productId,
                manufacturer: a.manufacturer,
                model: a.model,
                year: a.year,
                quantity: 1,
                discount: 0,
                category: a.category
            }
            aux.push(aju);
        })
        setAccessories(aux);

    }
    useEffect(() => {
        bikeProducts();
        partProducts();
        accessoryProducts();
    }, []);

    // console.log(bikes);
    // console.log("SELECTED", selected);

    const handleRequestSort = (event, property) => {
        const isAsc = orderBy === property && order === 'asc';
        setOrder(isAsc ? 'desc' : 'asc');
        setOrderBy(property);
    };
    const handleRequestSort2 = (event, property) => {
        const isAsc = orderBy2 === property && order === 'asc';
        setOrder2(isAsc ? 'desc' : 'asc');
        setOrderBy2(property);
    };
    const handleRequestSort3 = (event, property) => {
        const isAsc = orderBy3 === property && order === 'asc';
        setOrder3(isAsc ? 'desc' : 'asc');
        setOrderBy3(property);
    };

    const handleSelectAllClick = (event) => {
        if (event.target.checked) {
            const newSelecteds = bikes.map((n) => n); //AICI
            setSelected(newSelecteds);
            return;
        }
        setSelected([]);
    };
    const handleSelectAllClick2 = (event) => {
        if (event.target.checked) {
            const newSelecteds2 = parts.map((n) => n); //AICI
            setSelected2(newSelecteds2);
            return;
        }
        setSelected2([]);
    };
    const handleSelectAllClick3 = (event) => {
        if (event.target.checked) {
            const newSelecteds3 = accessories.map((n) => n); //AICI

            setSelected3(newSelecteds3);
            return;
        }
        setSelected3([]);
    };

    const handleClick = (event, product) => {
        const selectedIndex = selected.indexOf(product);
        let newSelected = [];

        if (selectedIndex === -1) {
            newSelected = newSelected.concat(selected, product);
        } else if (selectedIndex === 0) {
            newSelected = newSelected.concat(selected.slice(1));
        } else if (selectedIndex === selected.length - 1) {
            newSelected = newSelected.concat(selected.slice(0, -1));
        } else if (selectedIndex > 0) {
            newSelected = newSelected.concat(
                selected.slice(0, selectedIndex),
                selected.slice(selectedIndex + 1),
            );
        }

        setSelected(newSelected);
    };
    const handleClick2 = (event, product) => {
        const selectedIndex = selected2.indexOf(product);
        let newSelected = [];

        if (selectedIndex === -1) {
            newSelected = newSelected.concat(selected2, product);
        } else if (selectedIndex === 0) {
            newSelected = newSelected.concat(selected2.slice(1));
        } else if (selectedIndex === selected2.length - 1) {
            newSelected = newSelected.concat(selected2.slice(0, -1));
        } else if (selectedIndex > 0) {
            newSelected = newSelected.concat(
                selected2.slice(0, selectedIndex),
                selected2.slice(selectedIndex + 1),
            );
        }

        setSelected2(newSelected);
    };
    const handleClick3 = (event, product) => {

        const selectedIndex = selected3.indexOf(product);
        let newSelected = [];

        if (selectedIndex === -1) {
            newSelected = newSelected.concat(selected3, product);
        } else if (selectedIndex === 0) {
            newSelected = newSelected.concat(selected3.slice(1));
        } else if (selectedIndex === selected3.length - 1) {
            newSelected = newSelected.concat(selected3.slice(0, -1));
        } else if (selectedIndex > 0) {
            newSelected = newSelected.concat(
                selected3.slice(0, selectedIndex),
                selected3.slice(selectedIndex + 1),
            );
        }

        setSelected3(newSelected);
    };

    const handleChangePage = (event, newPage) => {
        setPage(newPage);
    };
    const handleChangePage2 = (event, newPage) => {
        setPage2(newPage);
    };
    const handleChangePage3 = (event, newPage) => {
        setPage3(newPage);
    };

    const handleChangeRowsPerPage = (event) => {
        setRowsPerPage(parseInt(event.target.value, 10));
        setPage(0);
    };
    const handleChangeRowsPerPage2 = (event) => {
        setRowsPerPage2(parseInt(event.target.value, 10));
        setPage2(0);
    };
    const handleChangeRowsPerPage3 = (event) => {
        setRowsPerPage3(parseInt(event.target.value, 10));
        setPage3(0);
    };

    const handleChangeDense = (event) => {
        setDense(event.target.checked);
    };
    const handleChangeQuantity= (row,value) => {
        var index = bikes.indexOf(row);
        bikes[index].quantity=parseInt(value);
        console.log(row,"JDAKS");
        console.log(index,"JDAKS");
 
     };
     const handleChangeDiscount = (row,value) => {
         var index = bikes.indexOf(row);
         bikes[index].discount=parseInt(value);
         var index = selected3.indexOf(row);
         console.log(row,"JDAKS2");
      };
      const handleChangeQuantity2 = (row,value) => {
        var index = parts.indexOf(row);
        parts[index].quantity=parseInt(value);
     //    console.log(row,"JDAKS");
     //    console.log(index,"JDAKS");
 
     };
     const handleChangeDiscount2 = (row,value) => {
         var index = parts.indexOf(row);
         parts[index].discount=parseInt(value);
         // var index = selected3.indexOf(row);
         // console.log(row,"JDAKS");
      };
    const handleChangeQuantity3 = (row,value) => {
       var index = accessories.indexOf(row);
       accessories[index].quantity=parseInt(value);
    //    console.log(row,"JDAKS");
    //    console.log(index,"JDAKS");

    };
    const handleChangeDiscount3 = (row,value) => {
        var index = accessories.indexOf(row);
        accessories[index].discount=parseInt(value);
        // var index = selected3.indexOf(row);
        // console.log(row,"JDAKS");
     };

    const isSelected = (productId) => selected.indexOf(productId) !== -1;
    const isSelected2 = (productId) => selected2.indexOf(productId) !== -1;
    const isSelected3 = (productId) => selected3.indexOf(productId) !== -1;

    // Avoid a layout jump when reaching the last page with empty rows.
    const emptyRows =
        page > 0 ? Math.max(0, (1 + page) * rowsPerPage - bikes.length) : 0;
    const emptyRows2 =
        page2 > 0 ? Math.max(0, (1 + page2) * rowsPerPage2 - parts.length) : 0;
    const emptyRows3 =
        page3 > 0 ? Math.max(0, (1 + page3) * rowsPerPage3 - accessories.length) : 0;


    const onFormSubmit = async (data) => {
        // console.log(data);
        // console.log(selected);
        // console.log("AICICICIICICICIC");
        console.log("DTA",data);
        data.file = file;

        try {
            var result = await promotionService.AddPromotion(data, selected,selected2,selected3, token);
        }
        catch (err) {
            console.log("Something went wrong", err);
            alert("Something went wrong!");
        }
        if (result >= 200 && result < 210)
            alert("Product added with success!")
        else alert("Something went wrong!");
        // window.location("/bikes");

    }

    // console.log("S1", selected);
    // console.log("S2", selected2);
    // console.log("S3", selected3);
    return (
        <div className="centerD">
            <div >
                <h1> Add promotion</h1>
                <form onSubmit={handleSubmit(onFormSubmit)} method="post">
                    <div className="txt_fieldD">
                        <input name="manufacturer" type="text"
                            {...register("name")}
                            asp-for="FileUpload.FormFile"
                            defaultValue=""
                        />
                        <div className="errorD">
                            {errors.name?.message}
                        </div>
                        <span></span>
                        <label>Name</label>
                    </div>

                    <div className="txt_fieldD">
                        <input type="file" name="file"
                            {...register("file")}
                            asp-for="FileUpload.FormFile"
                            style={{ marginLeft: "5%" }}
                            onChange={saveFile}
                        />
                        <div className="errorD">
                            {errors.file?.message}
                        </div>
                        <span></span>
                        <label>Image</label>
                    </div>
                    <div className="txt_fieldD">
                        <span>.</span>
                        <label style={{ color: "#1477b9", fontSize: "22px", fontWeight: "600" }}>Products</label>
                    </div>

                    <Box sx={{ width: '100%' }}>
                        <FormControlLabel
                            control={<Switch checked={dense} onChange={handleChangeDense} />}
                            label="Dense padding"
                        />
                        <Paper sx={{ width: '100%', mb: 2 }}>
                            <EnhancedTableToolbar numSelected={selected.length} tip={1} />
                            <TableContainer>
                                <Table
                                    sx={{ minWidth: 750 }}
                                    aria-labelledby="tableTitle"
                                    size={dense ? 'small' : 'medium'}
                                >
                                    <EnhancedTableHead
                                        numSelected={selected.length}
                                        order={order}
                                        orderBy={orderBy}
                                        onSelectAllClick={handleSelectAllClick}
                                        onRequestSort={handleRequestSort}
                                        rowCount={bikes.length}
                                    />
                                    <TableBody>
                                        {/* if you don't need to support IE11, you can replace the `stableSort` call with:
                 rows.slice().sort(getComparator(order, orderBy)) */}
                                        {stableSort(bikes, getComparator(order, orderBy))
                                            .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                                            .map((row, index) => {
                                                const isItemSelected = isSelected(row);
                                                const labelId = `enhanced-table-checkbox-${index}`;

                                                return (
                                                    <TableRow
                                                        hover
                                                        onClick={(event) => handleClick(event, row)}
                                                        role="checkbox"
                                                        aria-checked={isItemSelected}
                                                        tabIndex={-1}
                                                        key={row.productId}
                                                        selected={isItemSelected}
                                                    >
                                                        <TableCell padding="checkbox">
                                                            <Checkbox
                                                                color="primary"
                                                                checked={isItemSelected}
                                                                inputProps={{
                                                                    'aria-labelledby': labelId,
                                                                }}
                                                            />
                                                        </TableCell>
                                                        <TableCell
                                                            component="th"
                                                            id={labelId}
                                                            scope="row"
                                                            padding="none"
                                                        >
                                                            {row.productId}
                                                        </TableCell>
                                                        <TableCell align="right">{row.manufacturer}</TableCell>
                                                        <TableCell align="right">{row.model}</TableCell>
                                                        <TableCell align="right">{row.year}</TableCell>
                                                        <span>Quantity</span><input onChange={(event) => {handleChangeQuantity(row,event.target.value)}} style={{ width: "10%", marginTop: "6%", fontSize: "13px" }} type="number" />
                                                        <span style={{ marginLeft: "5%" }}>Discount</span><input onChange={(event) => {handleChangeDiscount(row,event.target.value)}} style={{ width: "10%", marginBottom: "5%", fontSize: "13px" }} type="number" />
                                                    </TableRow>
                                                );
                                            })}
                                        {emptyRows > 0 && (
                                            <TableRow
                                                style={{
                                                    height: (dense ? 33 : 53) * emptyRows,
                                                }}
                                            >
                                                <TableCell colSpan={6} />
                                            </TableRow>
                                        )}
                                    </TableBody>
                                </Table>
                            </TableContainer>
                            <TablePagination
                                rowsPerPageOptions={[5, 10, 25]}
                                component="div"
                                count={bikes.length}
                                rowsPerPage={rowsPerPage}
                                page={page}
                                onPageChange={handleChangePage}
                                onRowsPerPageChange={handleChangeRowsPerPage}
                            />
                        </Paper>
                    </Box>

                    <Box sx={{ width: '100%' }}>
                        <Paper sx={{ width: '100%', mb: 2 }}>
                            <EnhancedTableToolbar numSelected={selected2.length} tip={2} />
                            <TableContainer>
                                <Table
                                    sx={{ minWidth: 750 }}
                                    aria-labelledby="tableTitle"
                                    size={dense ? 'small' : 'medium'}
                                >
                                    <EnhancedTableHead
                                        numSelected={selected2.length}
                                        order={order2}
                                        orderBy={orderBy2}
                                        onSelectAllClick={handleSelectAllClick2}
                                        onRequestSort={handleRequestSort2}
                                        rowCount={parts.length}
                                    />
                                    <TableBody>

                                        {stableSort(parts, getComparator(order2, orderBy2))
                                            .slice(page2 * rowsPerPage2, page2 * rowsPerPage2 + rowsPerPage2)
                                            .map((row, index) => {
                                                const isItemSelected = isSelected2(row);
                                                const labelId = `enhanced-table-checkbox-${index}`;

                                                return (
                                                    <TableRow
                                                        hover
                                                        onClick={(event) => handleClick2(event, row)}
                                                        role="checkbox"
                                                        aria-checked={isItemSelected}
                                                        tabIndex={-1}
                                                        key={row.productId}
                                                        selected={isItemSelected}
                                                    >
                                                        <TableCell padding="checkbox">
                                                            <Checkbox
                                                                color="primary"
                                                                checked={isItemSelected}
                                                                inputProps={{
                                                                    'aria-labelledby': labelId,
                                                                }}
                                                            />
                                                        </TableCell>
                                                        <TableCell
                                                            component="th"
                                                            id={labelId}
                                                            scope="row"
                                                            padding="none"
                                                        >
                                                            {row.productId}
                                                        </TableCell>
                                                        <TableCell align="right">{row.manufacturer}</TableCell>
                                                        <TableCell align="right">{row.model}</TableCell>
                                                        <TableCell align="right">{row.year}</TableCell>
                                                        <span>Quantity</span><input onChange={(event) => {handleChangeQuantity2(row,event.target.value)}} style={{ width: "10%", marginTop: "6%", fontSize: "13px" }} type="number" />
                                                        <span style={{ marginLeft: "5%" }}>Discount</span><input onChange={(event) => {handleChangeDiscount2(row,event.target.value)}} style={{ width: "10%", marginTop: "6%", fontSize: "13px" }} type="number" />
                                                    </TableRow>
                                                );
                                            })}
                                        {emptyRows2 > 0 && (
                                            <TableRow
                                                style={{
                                                    height: (dense ? 33 : 53) * emptyRows2,
                                                }}
                                            >
                                                <TableCell colSpan={6} />
                                            </TableRow>
                                        )}
                                    </TableBody>
                                </Table>
                            </TableContainer>
                            <TablePagination
                                rowsPerPageOptions={[5, 10, 25]}
                                component="div"
                                count={parts.length}
                                rowsPerPage={rowsPerPage2}
                                page={page2}
                                onPageChange={handleChangePage2}
                                onRowsPerPageChange={handleChangeRowsPerPage2}
                            />
                        </Paper>

                    </Box>
                    <Box sx={{ width: '100%' }}>
                        <Paper sx={{ width: '100%', mb: 2 }}>
                            <EnhancedTableToolbar numSelected={selected3.length} tip={3} />
                            <TableContainer>
                                <Table
                                    sx={{ minWidth: 750 }}
                                    aria-labelledby="tableTitle"
                                    size={dense ? 'small' : 'medium'}
                                >
                                    <EnhancedTableHead
                                        numSelected={selected3.length}
                                        order={order3}
                                        orderBy={orderBy3}
                                        onSelectAllClick={handleSelectAllClick3}
                                        onRequestSort={handleRequestSort3}
                                        rowCount={accessories.length}
                                    />
                                    <TableBody>

                                        {stableSort(accessories, getComparator(order3, orderBy3))
                                            .slice(page3 * rowsPerPage3, page3 * rowsPerPage3 + rowsPerPage3)
                                            .map((row, index) => {
                                                const isItemSelected = isSelected3(row);
                                                const labelId = `enhanced-table-checkbox-${index}`;

                                                return (
                                                    <TableRow
                                                        hover
                                                        onClick={(event) => handleClick3(event, row)}
                                                        role="checkbox"
                                                        aria-checked={isItemSelected}
                                                        tabIndex={-1}
                                                        key={row.productId}
                                                        selected={isItemSelected}
                                                    >
                                                        <TableCell padding="checkbox">
                                                            <Checkbox
                                                                color="primary"
                                                                checked={isItemSelected}
                                                                inputProps={{
                                                                    'aria-labelledby': labelId,
                                                                }}
                                                            />
                                                        </TableCell>
                                                        <TableCell
                                                            component="th"
                                                            id={labelId}
                                                            scope="row"
                                                            padding="none"
                                                        >
                                                            {row.productId}

                                                        </TableCell>
                                                        <TableCell align="right">{row.manufacturer}</TableCell>
                                                        <TableCell align="right">{row.model}</TableCell>
                                                        <TableCell align="right">{row.year}</TableCell>
                                                            <span>Quantity</span><input onChange={(event) => {handleChangeQuantity3(row,event.target.value)}} style={{ width: "10%", marginTop: "6%", fontSize: "13px" }} type="number" />
                                                            <span style={{ marginLeft: "5%"  }}>Discount</span><input onChange={(event) => {handleChangeDiscount3(row,event.target.value)}} style={{ width: "10%", marginTop: "6%", fontSize: "13px" }} type="number" />
                                                        {/* onClick={() => handleChange(row.id)} */}
                                                        {/* <form style=><input type="text" value="discount"/></form> */}
                                                    </TableRow>

                                                );
                                            })}
                                        {emptyRows3 > 0 && (
                                            <TableRow
                                                style={{
                                                    height: (dense ? 33 : 53) * emptyRows3,
                                                }}
                                            >
                                                <TableCell colSpan={6} />
                                            </TableRow>
                                        )}
                                    </TableBody>
                                </Table>
                            </TableContainer>
                            <TablePagination
                                rowsPerPageOptions={[5, 10, 25]}
                                component="div"
                                count={accessories.length}
                                rowsPerPage={rowsPerPage3}
                                page={page3}
                                onPageChange={handleChangePage3}
                                onRowsPerPageChange={handleChangeRowsPerPage3}
                            />
                        </Paper>

                    </Box>
                    <input type="submit" onSubmit={handleSubmit(onFormSubmit)} name="submit" value="Next" />
                </form>
            </div>
        </div>
    );
}

