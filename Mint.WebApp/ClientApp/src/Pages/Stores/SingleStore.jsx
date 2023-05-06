import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";

const SingleStore = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [products, setProducts] = useState([]);

  const params = useParams();

  useEffect(() => {
    if (params.name) {
      setIsLoading(true);
      fetchWrapper
        .get("api/product/getsellerproductsbyname/" + params.name)
        .then((response) => {
          setIsLoading(false);
          setProducts(response);
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    }
  }, []);

  return (
    <div className={"page-content"}>
      {error ? <Error message={error} /> : null}
      {isLoading
        ? "Loading...."
        : products.map((product, key) => (
            <div key={key}>
              <img src={product.photos} alt={product.name} />
            </div>
          ))}
    </div>
  );
};

export default SingleStore;
