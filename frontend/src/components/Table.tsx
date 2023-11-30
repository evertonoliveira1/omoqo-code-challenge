import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import { Button } from '@mui/material';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import { useTranslation } from 'react-i18next';
import { Ship } from '../interfaces/Ship';
import TablePaginationContainer from './TablePaginationContainer';

export interface TableProps {
    rows: Ship[];
    handleDelete: Function;
    count: number;
    page: number;
    rowsPerPage: number;
    handleChangePage: any;
    handleChangeRowsPerPage: any;
};

const BasicTable = ({
    rows,
    handleDelete,
    page,
    count,
    rowsPerPage,
    handleChangePage,
    handleChangeRowsPerPage

}: TableProps) => {
    const { t } = useTranslation();

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>{t("deleteButton")}</TableCell>
                            <TableCell>{t("editButton")}</TableCell>
                            <TableCell>{t("name")}</TableCell>
                            <TableCell>{t("width")}</TableCell>
                            <TableCell>{t("length")}</TableCell>
                            <TableCell>{t("code")}</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows.map((row) => (
                            <TableRow
                                key={row.name}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell width={15}>
                                    <Button onClick={() => handleDelete(row.id)}
                                        startIcon={<DeleteIcon style={{ color: "#000" }} />}
                                    />
                                </TableCell>
                                <TableCell width={15}>
                                    <Button
                                        startIcon={<EditIcon style={{ color: "#000" }} />}
                                        href={`/update/${row.id}`}
                                    />
                                </TableCell>
                                <TableCell>{row.name}</TableCell>
                                <TableCell>{row.width}</TableCell>
                                <TableCell>{row.length}</TableCell>
                                <TableCell>{row.code}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>

            {rows && (<TablePaginationContainer
                count={count}
                page={page}
                rowsPerPage={rowsPerPage}
                handleChangePage={handleChangePage}
                handleChangeRowsPerPage={handleChangeRowsPerPage}
            />)}
        </>
    );
}

export default BasicTable;