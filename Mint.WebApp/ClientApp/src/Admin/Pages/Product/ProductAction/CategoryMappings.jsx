import React, { useEffect, useMemo, useState } from "react";
import DataTable from "react-data-table-component";
import { Button, Input, Spinner, TabPane } from "reactstrap";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";
import { Error } from "../../../../components/Notification/Error";
import { Success } from "../../../../components/Notification/Success";

const CategoryMappings = ({ isAdded, dataForUpdate }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [categories, setCategories] = useState([]);
  const [columnsToAdd, setColumnsToAdd] = useState([]);
  const [addingLoading, setAddingLoading] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState(null);

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/category/getonlycategories")
      .then((response) => {
        setIsLoading(false);
        setCategories(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  const handleAddClick = () => {
    setColumnsToAdd([...columnsToAdd, { id: columnsToAdd.length + 1 }]);
  };

  const handleAcceptClick = () => {
    console.log(selectedCategory);

    if (selectedCategory && selectedCategory !== "Выберете Категорию") {
      setAddingLoading(true);

      const data = {
        categoryId: selectedCategory,
        productId: dataForUpdate?.id,
        // displayOrder: console.log(e.target),
      };

      fetchWrapper
        .put("api/product/categorymappings", data)
        .then((response) => {
          setAddingLoading(false);
          setSuccess(response);
        })
        .catch((error) => {
          setAddingLoading(false);
          setError(error);
        });
    } else {
      setError("Выберете категорию");
    }
  };

  const handleRemoveClick = (row) => {
    const newItems = columnsToAdd.filter((x) => x.id !== row.id);
    setColumnsToAdd(newItems);
  };

  const handleCategoryChange = (e) => {
    setSelectedCategory(e.target.value);
  };

  useEffect(() => {
    window.addEventListener("change", handleCategoryChange, false);
  }, [selectedCategory]);

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
        name: <span className={"font-weight-bold fs-13"}>Категория</span>,
        selector: () => {
          return (
            <select
              name={"category"}
              className={"form-control"}
              placeholder={"Выберете Категорию"}
              onChange={handleCategoryChange}
            >
              <option>Выберете категорию</option>
              {categories.map((item, key) => (
                <option key={key} value={item.value}>
                  {item.label}
                </option>
              ))}
            </select>
          );
        },
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Показать</span>,
        selector: () => {
          return (
            <Input
              type={"number"}
              name={"displayOrder"}
              className={"form-control"}
              placeholder={"Введите порядок показа"}
              defaultValue={0}
            />
          );
        },
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Действие</span>,
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
              <Button
                color={"primary"}
                onClick={handleAcceptClick}
                disabled={addingLoading}
              >
                {addingLoading ? (
                  <Spinner className={"me-2"} size={"sm"}>
                    ...Loading
                  </Spinner>
                ) : null}{" "}
                <i className={"ri-check-line"}></i>
              </Button>
            </div>
          );
        },
      },
    ],
    [categories]
  );

  return (
    <TabPane tabId={4}>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success} /> : null}
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
              >
                <i className={"ri-add-line align-middle"}></i> Добавить
              </Button>
            </div>
            <DataTable
              columns={columns || []}
              data={columnsToAdd || categories || []}
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

export default CategoryMappings;
