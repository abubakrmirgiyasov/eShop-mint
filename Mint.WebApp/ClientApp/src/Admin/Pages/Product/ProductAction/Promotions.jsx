import React, { useEffect, useMemo, useState } from "react";
import { Error } from "../../../../components/Notification/Error";
import { Button, Input, TabPane } from "reactstrap";
import DataTable from "react-data-table-component";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";

const Promotions = ({ isAdded }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [categories, setCategories] = useState([]);
  const [columnsToAdd, setColumnsToAdd] = useState([]);

  // useEffect(() => {
  //   // setIsLoading(true);
  //   // fetchWrapper
  //   //   .get("api/manufacture/getonlymanufactures")
  //   //   .then((response) => {
  //   //     setIsLoading(false);
  //   //     setCategories(response);
  //   //   })
  //   //   .catch((error) => {
  //   //     setIsLoading(false);
  //   //     setError(error);
  //   //   });
  // }, []);

  const handleAddClick = () => {
    setColumnsToAdd([...columnsToAdd, columnsToAdd.length + 1]);
  };

  const handleAcceptClick = () => {};

  const handleRemoveClick = (row) => {
    const newItems = [...columnsToAdd];
    newItems.splice(row, 1);
    setColumnsToAdd(newItems);
  };

  const columns = useMemo(
    () => [
      {
        name: (
          <Input type={"checkbox"} className={"form-check"} disabled={true} />
        ),
        selector: (row) => <span>{row.displayOrder}</span>,
        cell: () => <Input type={"checkbox"} className={"form-check"} />,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Производитель</span>,
        selector: () => {
          return (
            <select name={"discount"} className={"form-control"}>
              <option>Выберете вид скидки</option>
              {categories.map((item) => (
                <option key={item.value} value={item.value}>
                  {item.label}
                </option>
              ))}
            </select>
          );
        },
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Показать</span>,
        selector: (row) => {
          return (
            <div
              className={"d-flex justify-content-between align-items-center"}
            >
              <Button
                color={"danger"}
                className={"me-2"}
                onClick={() => handleRemoveClick(row)}
              >
                <i className={"ri-close-line"}></i>
              </Button>
              <Button color={"primary"} onClick={handleAcceptClick}>
                <i className={"ri-check-line"}></i>
              </Button>
            </div>
          );
        },
      },
    ],
    []
  );

  return (
    <TabPane tabId={6}>
      {error ? <Error message={error} /> : null}
      {isAdded ? (
        isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <div className={"spinner-grow text-success"} role={"status"}>
              <span className={"visually-hidden"}>Loading...</span>
            </div>
          </div>
        ) : (
          <>
            <div className={"d-flex justify-content-start align-items-center"}>
              <Button
                className={"btn btn-success"}
                color={"success"}
                onClick={handleAddClick}
                // disabled={isLoading}
              >
                {/*{isLoading ? (*/}
                {/*  <Spinner className={"me-2"} size={"sm"}>*/}
                {/*    ...Loading*/}
                {/*  </Spinner>*/}
                {/*) : null}{" "}*/}
                <i className={"ri-add-line align-middle"}></i> Добавить
              </Button>
            </div>
            <DataTable
              columns={columns || []}
              data={columnsToAdd || []}
              pagination={true}
              highlightOnHover={true}
            />
          </>
        )
      ) : (
        <div className={"d-flex flex-column align-items-center"}>
          <h3 className={"text-center"}>
            Сначала вам нужно создать товар, чтобы заполнить остальные поля.
          </h3>
          <h5 className={"text-center text-muted fs-14 mt-3"}>
            Вернитесь на вкладку Информация чтобы создать.
          </h5>
        </div>
      )}
    </TabPane>
  );
};

export default Promotions;
