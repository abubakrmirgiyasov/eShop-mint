import { fetchWrapper } from "../../helpers/fetchWrapper";

const toggleLikes = (id) => {
  return fetchWrapper
    .get("api/like/getmylikes/" + id)
    .then((response) => {
        console.log(response)
      return response;
    })
    .catch((error) => {
      return error;
    });
};

const newLike = (values) => {
  return fetchWrapper
    .post("api/like/newlike", values)
    .then((response) => {
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

const removeLike = (values) => {
  return fetchWrapper
    .delete("api/like/removelike", values)
    .then((response) => {
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

export default { toggleLikes, newLike, removeLike };
