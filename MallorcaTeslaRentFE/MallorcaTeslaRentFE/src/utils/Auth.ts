export const GetAuth = () => {
    const token = localStorage.getItem('token');
    const refreshToken = localStorage.getItem('refreshToken');
    const user = localStorage.getItem('user');
    const isAuthenticated = token && refreshToken && user;
    return {
        token,
        refreshToken,
        user,
        isAuthenticated,
    };

}