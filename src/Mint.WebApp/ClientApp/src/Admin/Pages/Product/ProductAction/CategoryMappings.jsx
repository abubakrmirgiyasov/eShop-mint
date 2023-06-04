import React, { useEffect, useMemo, useState } from "react";
import { Button, Input, Spinner, TabPane } from "reactstrap";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";
import { Error } from "../../../../components/Notification/Error";
import { Success } from "../../../../components/Notification/Success";
import { Grid, _ } from "gridjs-react";
import Select from "react-select";

const CategoryMappings = ({ isAdded, dataForUpdate }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [categories, setCategories] = useState([]);
  const [columnsToAdd, setColumnsToAdd] = useState([]);
  const [addingLoading, setAddingLoading] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [temp, setTemp] = useState([]);

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

    setTemp([...temp, dataForUpdate]);
  }, []);

  const handleAddClick = () => {
    const cols = ["Категория", "Показать", "Действие"];
    setColumnsToAdd([...columnsToAdd, cols]);
  };

  const handleAcceptClick = () => {
    if (selectedCategory) {
      setAddingLoading(true);

      const data = {
        categoryId: selectedCategory,
        productId: dataForUpdate?.id,
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
    setSelectedCategory(e.value);
  };

  const columns = useMemo(
    () => [
      // {
      //   name: (
      //     <Input type={"checkbox"} className={"form-check"} disabled={true} />
      //   ),
      //   formatter: (row) => _(<span>{row.displayOrder}</span>),
      //   // cell: () => <Input type={"checkbox"} className={"form-check"} />,
      // },
      {
        name: "Категория",
        formatter: () =>
          _(
            <Select
              options={categories}
              defaultValue={""}
              onChange={handleCategoryChange}
            />
          ),
      },
      {
        name: "Показать",
        formatter: () =>
          _(
            <Input
              type={"number"}
              name={"displayOrder"}
              className={"form-control"}
              placeholder={"Введите порядок показа"}
              defaultValue={0}
            />
          ),
      },
      {
        name: "Действие",
        formatter: (row) =>
          _(
            <div className={"d-flex justify-content-end align-items-center"}>
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
                ) : (
                  <i className={"ri-check-line"}></i>
                )}
              </Button>
            </div>
          ),
      },
    ],
    [categories]
  );

  return (
    <TabPane tabId={4}>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success.message} /> : null}
      {isAdded ? (
        isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
          <Spinner color={"success"} size={"sm"}>
              Loading...
            </Spinner>
          </div>
        ) : (
          <>
            <Select
              options={categories}
              defaultValue={""}
              onChange={handleCategoryChange}
            />
            <Button
              color={"primary"}
              onClick={handleAcceptClick}
              disabled={addingLoading}
            >
              {addingLoading ? (
                <Spinner className={"me-2"} size={"sm"}>
                  ...Loading
                </Spinner>
              ) : (
                <i className={"ri-check-line"}></i>
              )}
            </Button>
            {/*<div className={"d-flex justify-content-start align-items-center"}>*/}
            {/*  <Button*/}
            {/*    className={"btn btn-success mb-3"}*/}
            {/*    color={"success"}*/}
            {/*    onClick={handleAddClick}*/}
            {/*  >*/}
            {/*    <i className={"ri-add-line align-middle"}></i> Добавить*/}
            {/*  </Button>*/}
            {/*</div>*/}
            {/*<Grid data={columnsToAdd || []} columns={columns} sort={true} />*/}
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
