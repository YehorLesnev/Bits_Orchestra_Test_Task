import * as React from 'react';
import Box from '@mui/material/Box';
import { useState } from 'react';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/DeleteOutlined';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Close';
import UploadFileIcon from '@mui/icons-material/UploadFile';
import {
  GridRowModes,
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
} from '@mui/x-data-grid';
import {
  randomId,
} from '@mui/x-data-grid-generator';

import Papa from 'papaparse';
import { baseUrl } from '../../config/config';

function EditToolbar(props) {
  const { setRows, setRowModesModel } = props;

  const handleClick = () => {
    const id = randomId();
    setRows((oldRows) => [...oldRows, { id, employee_id: null, employee_name: '', employee_date_of_birth: new Date(), is_married: false, employee_phone: '', employee_salary: 0 }]);
    setRowModesModel((oldModel) => ({
      ...oldModel,
      [id]: { mode: GridRowModes.Edit, fieldToFocus: 'employee_name' },
    }));
  };

  const handleUploadCSV = () => {
    document.getElementById('csv-file-input').click();
  };

  const handleSaveDataClick = () => {
    document.getElementById('save-data-button').click();
  };

  return (
    <GridToolbarContainer>
      <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
        Add Employee
      </Button>
      <Button color="primary" startIcon={<UploadFileIcon />} onClick={handleUploadCSV}>
        Upload CSV file
      </Button>
      <Button color="primary" startIcon={<SaveIcon />} onClick={handleSaveDataClick}>
        Save to Database
      </Button>
    </GridToolbarContainer>
  );
}

export default function EmployeeDataGrid() {
  const [rows, setRows] = useState([]);
  const [rowModesModel, setRowModesModel] = React.useState({});

  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const handleEditClick = (id) => () => {
    console.log(id)
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.Edit } });
  };

  const handleSaveClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.View } });
  };

  const handleDeleteClick = (id) => () => {
    setRows(rows.filter((row) => row.id !== id));
  };

  const handleCancelClick = (id) => () => {
    setRowModesModel({
      ...rowModesModel,
      [id]: { mode: GridRowModes.View, ignoreModifications: true },
    });

    setRows(rows.filter((row) => row.id !== id));
  };

  const processRowUpdate = (newRow) => {
    const rowIndex = rows.findIndex((row) => row.id === newRow.id);
    if (rowIndex !== -1) {
      const updatedRows = [...rows];
      updatedRows[rowIndex] = newRow;
      setRows(updatedRows);
    }

    return newRow;
  };

  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };

  const columns = [
    // { field: 'id', headerName: 'ID', width: 90 },
    {
      field: 'employee_name',
      headerName: 'Name',
      width: 120,
      editable: true,
    },
    {
      field: 'employee_date_of_birth',
      headerName: 'Date Of Birth',
      type: 'date',
      width: 100,
      editable: true,
    },
    {
      field: 'is_married',
      headerName: 'Married',
      type: 'boolean',
      width: 110,
      editable: true,
    },
    {
      field: 'employee_phone',
      headerName: 'Phone',
      sortable: true,
      width: 100,
      editable: true,
    },
    {
      field: 'employee_salary',
      headerName: 'Salary',
      sortable: true,
      type: 'number',
      width: 100,
      editable: true,
    },
    {
      field: 'actions',
      type: 'actions',
      headerName: 'Actions',
      width: 100,
      cellClassName: 'actions',
      getActions: ({ id }) => {
        const isInEditMode = rowModesModel[id]?.mode === GridRowModes.Edit;

        if (isInEditMode) {
          return [
            <GridActionsCellItem
              icon={<SaveIcon />}
              label="Save"
              sx={{
                color: 'primary.main',
              }}
              onClick={handleSaveClick(id)}
            />,
            <GridActionsCellItem
              icon={<CancelIcon />}
              label="Cancel"
              className="textPrimary"
              onClick={handleCancelClick(id)}
              color="inherit"
            />,
          ];
        }

        return [
          <GridActionsCellItem
            icon={<EditIcon />}
            label="Edit"
            className="textPrimary"
            onClick={handleEditClick(id)}
            color="inherit"
          />,
          <GridActionsCellItem
            icon={<DeleteIcon />}
            label="Delete"
            onClick={handleDeleteClick(id)}
            color="inherit"
          />,
        ];
      }
    }
  ];

  const handleFileInputChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      Papa.parse(file, {
        header: true,
        skipEmptyLines: true,

        transform: (value, header) => {
          if (header === 'employee_date_of_birth') {

            const parts = value.split('.');
            const dateString = `${parts[1]}/${parts[0]}/${parts[2]}`;

            return new Date(dateString);
          } else if (header === 'is_married') {
            return value === '0' ? false : true
          }

          // Return the value as is for other fields
          return value;
        },

        complete: (result) => {
          if (result.data.length > 0) {
            setRows(result.data);
          } else {
            console.error('CSV file is empty');
          }
        },
        error: (error) => {
          console.error('Error parsing CSV file:', error);
        },
      });
    }
  };

  function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;

    return [year, month, day].join('-');
}

  const handleSaveData = () => {
    const resultRows = rows.map((row) => {

      return {
        employee_id: row.employee_id,
        employee_name: row.employee_name,
        employee_date_of_birth: formatDate(row.employee_date_of_birth),
        employee_phone: row.employee_phone,
        employee_salary: row.employee_salary,
        is_married: row.is_married
      };
    });

console.log(resultRows)

    fetch(baseUrl + '/Employee/update-all', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        employees: resultRows
      }),
    })
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => {
        console.log('Data saved successfully:', data);
      })
      .catch(error => {
        console.error('Error saving data:', error);
      });
  };
  return (
    <Box
      sx={{
        height: 500,
        width: '100%',
        '& .actions': {
          color: 'text.secondary',
        },
        '& .textPrimary': {
          color: 'text.primary',
        },
      }}
    >
      <input id="csv-file-input" type="file" accept=".csv" style={{ display: 'none' }} onChange={handleFileInputChange} />
      <button id="save-data-button" style={{ display: 'none' }} onClick={handleSaveData} />
      <DataGrid
        getRowId={(row) => !row.employee_id ? row.id : row.employee_id}
        rows={rows}
        columns={columns}
        editMode="row"
        rowModesModel={rowModesModel}
        onRowModesModelChange={handleRowModesModelChange}
        onRowEditStop={handleRowEditStop}
        processRowUpdate={processRowUpdate}
        slots={{
          toolbar: EditToolbar,
        }}
        slotProps={{
          toolbar: { setRows, setRowModesModel },
        }}
      />
    </Box>
  );
}