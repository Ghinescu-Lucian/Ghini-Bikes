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
import IconButton from '@mui/material/IconButton';
import Tooltip from '@mui/material/Tooltip';
import FormControlLabel from '@mui/material/FormControlLabel';
import Switch from '@mui/material/Switch';
import DeleteIcon from "@material-ui/icons/Delete";
//'@mui/icons-material/Delete';
import FilterListIcon from "@material-ui/icons/FilterList";
//'@mui/icons-material/FilterList';
import { visuallyHidden } from '@mui/utils';
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from '@hookform/resolvers/yup';
import "./CSS/DataTable.css";
import * as partService from '../Services/PartService.js';






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
    const { numSelected } = props;

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
                    Bikes Compatibilities
                </Typography>
            )}

            {numSelected > 0 ? (
                <Tooltip title="Delete">
                    <IconButton>
                        <DeleteIcon />
                    </IconButton>
                </Tooltip>
            ) : (
                <Tooltip title="Filter list">
                    <IconButton>
                        <FilterListIcon />
                    </IconButton>
                </Tooltip>
            )}
        </Toolbar>
    );
};

EnhancedTableToolbar.propTypes = {
    numSelected: PropTypes.number.isRequired,
};

const schema = yup.object()
    .shape({
        manufacturer: yup.string().required(),
        model: yup.string().required(),
        year: yup.number().min(2000).required(),
        description: yup.string().required(),
        price: yup.number().required(),
        quantity: yup.number().min(1).required(),
        file: yup.mixed().required('File is required'),

    })
    .required();

export default function EnhancedTable() {
    const [order, setOrder] = React.useState('asc');
    const [orderBy, setOrderBy] = React.useState('calories');
    const [selected, setSelected] = React.useState([]);
    const [page, setPage] = React.useState(0);
    const [dense, setDense] = React.useState(false);
    const [rowsPerPage, setRowsPerPage] = React.useState(5);

    const [bikes, setBikes] = useState([]);
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
                year: a.year
            }
            aux.push(aju);
        })
        setBikes(aux);

    }
    useEffect(() => {
        bikeProducts();
    }, []);

    // console.log(bikes);
    // console.log("SELECTED", selected);

    const handleRequestSort = (event, property) => {
        const isAsc = orderBy === property && order === 'asc';
        setOrder(isAsc ? 'desc' : 'asc');
        setOrderBy(property);
    };

    const handleSelectAllClick = (event) => {
        if (event.target.checked) {
            const newSelecteds = bikes.map((n) => n.productId); //AICI
            setSelected(newSelecteds);
            return;
        }
        setSelected([]);
    };

    const handleClick = (event, productId) => {
        const selectedIndex = selected.indexOf(productId);
        let newSelected = [];

        if (selectedIndex === -1) {
            newSelected = newSelected.concat(selected, productId);
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

    const handleChangePage = (event, newPage) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {
        setRowsPerPage(parseInt(event.target.value, 10));
        setPage(0);
    };

    const handleChangeDense = (event) => {
        setDense(event.target.checked);
    };

    const isSelected = (productId) => selected.indexOf(productId) !== -1;

    // Avoid a layout jump when reaching the last page with empty rows.
    const emptyRows =
        page > 0 ? Math.max(0, (1 + page) * rowsPerPage - bikes.length) : 0;


    const onFormSubmit = async (data) => {
        console.log(data);
        console.log(selected);
        data.file = file;
       
            try {
                var AddBike_Result = await partService.AddPart(data,selected, token);
            }
            catch (err) {
                console.log("Something went wrong", err);
                alert("Something went wrong!");
            }
            if (AddBike_Result >= 200 && AddBike_Result < 210)
                alert("Product added with success!")
            else alert("Something went wrong!");
            // window.location("/bikes");
        
    }


    return (
        <div className="centerD">
            <div >
                <h1> Add part</h1>
                <form onSubmit={handleSubmit(onFormSubmit)} method="post">
                    <div className="txt_fieldD">
                        <input name="manufacturer" type="text"
                            {...register("manufacturer")}
                            asp-for="FileUpload.FormFile"
                            defaultValue="Proba"
                        />
                        <div className="errorD">
                            {errors.manufacturer?.message}
                        </div>
                        <span></span>
                        <label>Manufacturer</label>
                    </div>
                    <div className="txt_fieldD">
                        <input name="model" type="text"
                            {...register("model")}
                            asp-for="FileUpload.FormFile"
                            defaultValue="Proba"
                        />
                        <div className="errorD">
                            {errors.model?.message}
                        </div>
                        <span></span>
                        <label>Model</label>
                    </div>
                    <div className="txt_fieldD">
                        <input name="year" type="text"
                            {...register("year")}
                            asp-for="FileUpload.FormFile"
                            defaultValue="2022"
                        />
                        <div className="errorD">
                            {errors.year?.message}
                        </div>
                        <span></span>
                        <label>Year</label>
                    </div>
                    <div className="txt_fieldD">
                        <div className="errorD">
                            {errors.description?.message}
                        </div>
                        <span></span>
                        <textarea className="ckeditor" name="description" rows={4} cols={45}
                            {...register("description")}
                            asp-for="FileUpload.FormFile"
                            defaultValue="Description"></textarea>
                    </div>
                    <div className="txt_fieldD">
                        <input name="price" type="text"
                            {...register("price")}
                            asp-for="FileUpload.FormFile"
                            defaultValue="2022"
                        />
                        <div className="errorD">
                            {errors.price?.message}
                        </div>
                        <span></span>
                        <label>Price</label>
                    </div>
                    <div className="txt_fieldD">
                        <input name="quantity" type="text"
                            {...register("quantity")}
                            asp-for="FileUpload.FormFile"
                            defaultValue="2022"
                        />
                        <div className="errorD">
                            {errors.quantity?.message}
                        </div>
                        <span></span>
                        <label>Quantity</label>
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

                    <Box sx={{ width: '100%' }}>
                        <Paper sx={{ width: '100%', mb: 2 }}>
                            <EnhancedTableToolbar numSelected={selected.length} />
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
                                                const isItemSelected = isSelected(row.productId);
                                                const labelId = `enhanced-table-checkbox-${index}`;

                                                return (
                                                    <TableRow
                                                        hover
                                                        onClick={(event) => handleClick(event, row.productId)}
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
                        <FormControlLabel
                            control={<Switch checked={dense} onChange={handleChangeDense} />}
                            label="Dense padding"
                        />
                    </Box>
                    <input type="submit" name="submit" value="Upload" />
                </form>
            </div>
        </div>
    );
}
