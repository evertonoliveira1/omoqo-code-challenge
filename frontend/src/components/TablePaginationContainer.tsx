import TablePagination from '@mui/material/TablePagination';

interface TablePaginationProps {
    count: number;
    page: number;
    rowsPerPage: number;
    handleChangePage: any;
    handleChangeRowsPerPage: any;
}

export const TablePaginationContainer = ({ 
    count,
    page,
    rowsPerPage,
    handleChangePage,
    handleChangeRowsPerPage
}: TablePaginationProps) => {
    return (
        <TablePagination
            component="div"
            count={count}
            page={page}
            onPageChange={handleChangePage}
            rowsPerPage={rowsPerPage}
            rowsPerPageOptions={[5, 10, 50, 100, 200]}
            onRowsPerPageChange={handleChangeRowsPerPage}
        />
    );
}

export default TablePaginationContainer;